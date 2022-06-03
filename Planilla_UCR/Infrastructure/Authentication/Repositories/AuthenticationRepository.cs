using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Authentication.Repositories;
using Domain.Accounts.DTOs;

namespace Infrastructure.Authentication.Repositories
{
    internal class AuthenticationRepository : IAuthenticationRepository
    {
        private UserManager<IdentityUser> _userManager;

        public AuthenticationRepository(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<bool> RegisterRequestAsync(AccountsDTO accountData)
        {
            bool success = false;
            var user = new IdentityUser()
            {
                UserName = accountData.Email,
                Email = accountData.Email,  
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, accountData.UserPassword);

            if (result.Succeeded)
            {
                /* await sendConfirmation(r.Email);*/
                success = true;
                /* await personService.registerUser(r);
                 await profileService.registerUser(r);*/
            }
            return success;
        }
    }
}
