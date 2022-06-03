using System.Threading.Tasks;
using Domain.Authentication.Repositories;
using Domain.Accounts.DTOs;

namespace Application.Authentication.Implementations
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository auth)
        {
            _authenticationRepository = auth;
        }

        public async Task<bool> RegisterRequestAsync(AccountsDTO accountData)
        {
            return await _authenticationRepository.RegisterRequestAsync(accountData);
        }
    }
}
