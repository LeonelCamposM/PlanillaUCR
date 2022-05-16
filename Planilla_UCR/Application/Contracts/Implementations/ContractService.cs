using Domain.Core.Repositories;
using Domain.Contracts.DTOs;
using Domain.Contracts.Entities;
using Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Implementations
{
    internal class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository) 
        {
            _contractRepository = contractRepository;
        }

        public async Task CreateContractAsync(String employeeEmail, string projectEmail, string projectName, int mountPerHour, string typeOfContract, string date, int duration)
        {
            await _contractRepository.CreateContractAsync(employeeEmail, projectEmail, projectName, mountPerHour, typeOfContract, date, duration);
        }
    }
}
