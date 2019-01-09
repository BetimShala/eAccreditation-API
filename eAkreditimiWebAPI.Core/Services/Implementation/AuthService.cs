using e_AkreditimiWebAPI.Core.Services.Contract;
using e_AkreditimiWebAPI.Infrastructure.Models;
using e_AkreditimiWebAPI.Infrastructure.Models.Authentication;
using eAkreditimiWebAPI.Core.Helpers.Implementation;
using eAkreditimiWebAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eAkreditimiWebAPI.Core.Services.Implementation
{
    public class AuthService : ServiceBase<ApplicationUser>, IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthService(UserManager<ApplicationUser> userManager,
                           SignInManager<ApplicationUser> signInManager,
                           DataContext context) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Authenticate(string email, string password, bool rememberMe)
            => await _signInManager.PasswordSignInAsync(email, password, rememberMe = false, false);

        public async Task<bool> Register(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PersonalNumber = model.PersonalNumber,                
                BirthDate = model.BirthDate,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CountryId = model.CountryId,
                IsMale = model.IsMale,
                MaidenName = model.MaidenName,                
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {               
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.AddToRoleAsync(user, "AcademicStaff");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }
            return false;
        }

        public ApplicationUser GetLoggedUser(string email) => _userManager.FindByEmailAsync(email).Result;


        public ApplicationUser GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }

        
    }
}
