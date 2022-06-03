using System.Threading.Tasks;
using Domain.Accounts.DTOs;

namespace Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterRequestAsync(AccountsDTO accountData);
    }
}
