using Domain.Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Agreements.Repositories
{
    public interface IAgreementRepository
    {
        Task CreateAgreementAsync(Agreement agreement);
        Task<Agreement>? GetContractee(Agreement agreement);
        Task<IEnumerable<Agreement>> GetEmployeeAgreements(string employeeEmail);
        Task<IEnumerable<Agreement>> GetEmployerAgreements(string employerEmail);
        Task<IEnumerable<Agreement?>> GetAllAgreementsByProjectAndEmployer(string projectName, string employerEmail);
        Task DesactivateAgreement(string employeeEmail, string employerEmail, string projectName, string justification);
    }
}
