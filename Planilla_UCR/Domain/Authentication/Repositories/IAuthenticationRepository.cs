using Domain.Accounts.DTOs;
using System.Threading.Tasks;

namespace Domain.Authentication.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<bool> RegisterRequestAsync(AccountsDTO accountData);

    }
}
