using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using e_AkreditimiWebAPI.Core.Services.Contract;
using e_AkreditimiWebAPI.Infrastructure.Data.API_TestData;
using e_AkreditimiWebAPI.Infrastructure.Models;
using e_AkreditimiWebAPI.Infrastructure.Models.Authentication;
using eAkreditimiWebAPI.Core.Services.API_TestDataService;
using eAkreditimiWebAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace eAkreditimiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IAPIService _apiService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(
                    IAuthService authService,
                    IOptions<AppSettings> appSettings, 
                    UserManager<ApplicationUser> userManager,
                    IAPIService apiService)
        {
            _authService = authService;
            _appSettings = appSettings;
            _userManager = userManager;
            _apiService = apiService;
        }


        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] LoginViewModel model)
        {
            //var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            var user = _authService.Authenticate(model.Email, model.Password, model.RememberMe);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            if (user.Result.Succeeded)
            {
                var loggedUser = _authService.GetLoggedUser(model.Email);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, loggedUser.Id),
                    new Claim(ClaimTypes.Role,_userManager.GetRolesAsync(loggedUser).Result.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string retToken = tokenHandler.WriteToken(token);

                return Ok(retToken);
            }
            return Ok("authentication failed");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _authService.Register(model);
            return Ok(result);
        }

        [HttpPost("arc/personalNumber/{personalNumber}")]
        [AllowAnonymous]
        public IActionResult FindPersonByPersonalNumber([FromRoute] string personalNumber)
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://127.0.0.1:3000/api/users/"+personalNumber).Result;
            var content = response.Content.ReadAsStringAsync()
                                       .Result
                                       .Replace("\\", "")
                                       .Trim(new char[1] { '"' });
            var user = JsonConvert.DeserializeObject<ARC_API>(content);
            return Ok(user);
        }

        [HttpGet("academic-staff")]
        public IActionResult Clients()
        {
            var users = _authService.GetUsersByRole("AcademicStaff");
            return Ok(users);
        }

    }
}