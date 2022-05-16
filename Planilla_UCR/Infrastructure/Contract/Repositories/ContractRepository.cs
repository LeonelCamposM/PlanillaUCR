using Domain.Core.Repositories;
using Domain.Contract.DTOs;
using Domain.Contract.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract.Repositories
{
    internal class ContractRepository : IContractRepository
    {
        private readonly ContractDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public ContractRepository(ContractDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }
        
        public async Task CreateContractAsync(String employeeEmail, string projectEmail, string projectName, int mountPerHour, string typeOfContract, string date, int duration)
        {
            Contract c = new Contract(employeeEmail, projectEmail, projectName, mountPerHour, typeOfContract, date, duration);
            _dbContext.Contract.Add(c);
            await _dbContext.SaveEntitiesAsync();
        }
    }
}
