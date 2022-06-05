using Domain.Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Agreements.Repositories
{
    public interface IAgreementRepository
    {
        Task CreateAgreementAsync(Agreement agreement);

        //Task CreateAgreementAsync(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate);
        Task<Agreement>? GetContracteeByEmail(Agreement agreement);

        Task<IEnumerable<Agreement>> GetAgreement(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate);
    }
}
