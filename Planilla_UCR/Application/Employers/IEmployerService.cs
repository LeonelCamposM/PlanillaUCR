using Domain.Employers.Entities;
using System;
using System.Threading.Tasks;
using Domain.Employers.Entities;


namespace Application.Employers
{
    public interface IEmployerService
    {
        Task CreateEmployerAsync(String email);
        Task<Employer>? GetEmployerAsync(String email);
    }
}