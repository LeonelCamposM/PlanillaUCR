using Domain.Core.Repositories;
using Domain.Agreements.Entities;
using Domain.Agreements.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


using System.Linq;

namespace Infrastructure.Agreements.Repositories
{
    internal class AgreementRepository : IAgreementRepository
    {
        private readonly AgreementDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AgreementRepository(AgreementDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateAgreementAsync(Agreement agreement)

        {
            _dbContext.Agreements.Add(agreement);
            await _dbContext.SaveEntitiesAsync();
        }
        /*
        public async Task<IEnumerable<Agreement?>> GetContracteeByEmail(Agreement agreement)
        {
        /*
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public string ContractStartDate { get; set; }
        public String ContractType { get; set; }
        public int MountPerHour { get; set; }
        public string ContractFinishDate { get; set; }
        


        var contracteeList = await _dbContext.Agreements.FromSqlRaw("EXEC GetContracteeByEmail @agreement.EmployeeEmail",
                new SqlParameter("employeeEmail", agreement.EmployeeEmail)).ToListAsync();
            return contracteeList;
        }
        */
        public async Task<Agreement>? GetContracteeByEmail(Agreement agreement)
        {
            IList<Agreement> agreementList = await _dbContext.Agreements.Where
                (e => e.EmployeeEmail == agreement.EmployeeEmail && e.EmployerEmail == agreement.EmployerEmail
                && e.ProjectName == agreement.ProjectName).ToListAsync();
            Agreement agreementAux = null;
            if (agreementList.Length() > 0)
            {
                agreementAux = agreementList.First();
            }
            return agreementAux;

        }


        /*public async Task<Subscription>? GetSubscription(string employerEmail, string projectName, string subscriptionName)
        {
            IList<Subscription> subscriptionResult = await _dbContext.Subscriptions.Where
                (e => e.EmployerEmail == employerEmail && e.SubscriptionName == subscriptionName
                && e.ProjectName == projectName).ToListAsync();
            Subscription subscription = null;
            if (subscriptionResult.Length() > 0)
            {
                subscription = subscriptionResult.First();
            }
            return subscription;
        }

        */

        public async Task<IEnumerable<Agreement?>> GetAgreement(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate)
        {
            // TODO: StoredProcedure. Next code is just a placeholder
            var employeeList = await _dbContext.Agreements.FromSqlRaw("EXEC GetEmployeeByEmail @email",
                new SqlParameter("email", employeeEmail)).ToListAsync();
            return employeeList;
        }
    }
}

/*
         public async Task<IEnumerable<Employee?>> GetEmployeeByEmail(string email)
        {
            var employeeList = await _dbContext.Employees.FromSqlRaw("EXEC GetEmployeeByEmail @email",
                new SqlParameter("email", email)).ToListAsync();
            return employeeList;
        }
~~~
 */