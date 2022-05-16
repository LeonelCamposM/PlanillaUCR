using Domain.Contract.DTOs;
using Domain.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Contract
{
    public interface IContractService
    {
        Task CreateContractAsync(String employeeEmail, string projectEmail, string projectName, int mountPerHour, string typeOfContract, string date, int duration);
    }
}
