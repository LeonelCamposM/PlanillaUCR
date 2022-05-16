using Domain.Contracts.DTOs;
using Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IContractRepository
    {
        Task CreateContractAsync(String employeeEmail,string projectEmail, string projectName, int mountPerHour, string typeOfContract, string date, int duration);
    }
}
