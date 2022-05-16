using Domain.Contracts.DTOs;
using Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Contracts
{
    public interface IContractService
    {
        Task CreateContractAsync(String employeeEmail, string projectEmail, string projectName, int mountPerHour, string typeOfContract, string date, int duration);
    }
}
