using Domain.Core.Repositories;
using Domain.Subscribes.Entities;
using Domain.Subscribes.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Subscribes.Repositories
{
    internal class SubscribeRepository : ISubscribeRepository
    {
        private readonly SubscribeDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public SubscribeRepository(SubscribeDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<IEnumerable<Subscribe>> GetEmployeesBySubscription(string employerEmail, string projectName, string subscriptionName)
        {
            return await _dbContext.Subscribes.FromSqlRaw("EXEC GetEmployeesBySubscription @EmployerEmail," +
                " @ProjectName, @SubscriptionName;",
                new SqlParameter("EmployerEmail", employerEmail),
                new SqlParameter("ProjectName", projectName),
                new SqlParameter("SubscriptionName", subscriptionName)).ToListAsync();
        }

        public async Task CreateSubscribeAsync(Subscribe subscription)
        {
            _dbContext.Subscribes.Add(subscription);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Subscribe>> GetBenefitsByEmployee(string employeeEmail, string projectName)
        {
            return await _dbContext.Subscribes.FromSqlRaw("EXEC GetEmployeeBenefits @EmployeeEmail," +
               " @ProjectName;",
               new SqlParameter("EmployeeEmail", employeeEmail),
               new SqlParameter("ProjectName", projectName)).ToListAsync();
        }

        public async Task<IEnumerable<Subscribe>> GetDeductionsByEmployee(string employeeEmail, string projectName)
        {
            return await _dbContext.Subscribes.FromSqlRaw("EXEC GetEmployeeDeductions @EmployeeEmail," +
               " @ProjectName;",
               new SqlParameter("EmployeeEmail", employeeEmail),
               new SqlParameter("ProjectName", projectName)).ToListAsync();
        }
    }
}