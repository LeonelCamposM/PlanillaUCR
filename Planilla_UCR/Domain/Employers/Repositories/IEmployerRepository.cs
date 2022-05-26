using Domain.Employers.Entities;
using System;
using Domain.Employers.Entities;
using System.Threading.Tasks;

namespace Domain.Employers.Repositories
{
    public interface IEmployerRepository
    {
        Task CreateEmployerAsync(String email);
        Task<Employer>? GetEmployerAsync(String email);
    }
}
