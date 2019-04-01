using e_AkreditimiWebAPI.Infrastructure.Models;
using e_AkreditimiWebAPI.Infrastructure.Models.Authentication;
using e_AkreditimiWebAPI.Infrastructure.ViewModels;
using eAkreditimiWebAPI.Core.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace e_AkreditimiWebAPI.Core.Services.Contract
{
    public interface IAuthService : IServiceBase<ApplicationUser>
    {
        Task<SignInResult> Authenticate(string email, string password, bool rememberMe);

        Task<bool> Register(RegisterModel model);

        Task LogOutAsync();

        ApplicationUser GetLoggedUser(string email);

        ApplicationUser GetUserById(string id);
        IEnumerable<UserListViewModel> GetUsersByRole(string role);

    }
}
