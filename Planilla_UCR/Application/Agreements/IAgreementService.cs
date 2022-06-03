using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Agreements.Entities;

namespace Application.Agreements
{
    public interface IAgreementService
    {
        Task CreateAgreementAsync(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate);

        Task<IEnumerable<Agreement>> GetAgreement(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate);
    }
}
