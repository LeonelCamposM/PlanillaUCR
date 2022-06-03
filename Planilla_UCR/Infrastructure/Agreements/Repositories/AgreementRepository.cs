using Domain.Core.Repositories;
using Domain.Agreements.Entities;
using Domain.Agreements.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

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

        public async Task CreateAgreementAsync(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate)
        {
            _dbContext.Add(new Agreement(employeeEmail, employerEmail, projectName, contractStartDate, contractType, mountPerHour, contractFinishDate));
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Agreement?>> GetAgreement(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate)
        {
            // TODO: StoredProcedure. Next code is just a placeholder
            var employeeList = await _dbContext.Agreements.FromSqlRaw("EXEC GetEmployeeByEmail @email",
                new SqlParameter("email", employeeEmail)).ToListAsync();
            return employeeList;
        }
    }
}
