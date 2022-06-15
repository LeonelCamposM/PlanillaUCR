using Domain.Core.Repositories;
using Domain.Subscribes.Entities;
using Domain.Subscribes.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
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
            IList<Subscribe> employees = await _dbContext.Subscribes.Where
                (e => e.EmployerEmail == employerEmail && e.SubscriptionName == subscriptionName
                && e.ProjectName == projectName).ToListAsync();
            return employees;
        }

        public async Task CreateSubscribeAsync(Subscribe subscription)
        {
            _dbContext.Subscribes.Add(subscription);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}