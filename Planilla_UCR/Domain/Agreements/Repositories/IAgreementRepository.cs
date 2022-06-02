using Domain.Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Agreements.Repositories
{
    public interface IAgreementRepository
    {
        Task CreateAgreementAsync(string employeeEmail, string employerEmail, string projectName, DateTime contractStartDate, string contractType, int mountPerHour, DateTime contractFinishDate);
        Task<IEnumerable<Agreement>> GetEAgreement(string employeeEmail, string employerEmail, string projectName, DateTime contractStartDate, string contractType, int mountPerHour, DateTime contractFinishDate);
    }
}
