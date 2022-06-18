﻿using Domain.Core.Repositories;
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

        public async Task<IEnumerable<Subscribe>> GetSubscriptionCostsByDate(Subscribe searchSubscription)
        {
            IEnumerable<Subscribe>  subscriptionCosts =  await _dbContext.Subscribes.Where( e => e.EmployerEmail == searchSubscription.EmployerEmail &&
            e.ProjectName == searchSubscription.ProjectName &&
            e.EmployeeEmail == searchSubscription.EmployeeEmail && ( (e.EndDate == null && e.StartDate <= searchSubscription.EndDate) || (searchSubscription.EndDate >= e.EndDate && e.EndDate >= searchSubscription.StartDate) )).ToListAsync();
            return subscriptionCosts;
        }
    }
} 