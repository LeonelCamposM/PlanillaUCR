using Domain.Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Agreements.Repositories
{
    public interface IAgreementRepository
    {
        Task CreateAgreementAsync(Agreement agreement);
        Task<Agreement>? GetContracteeByEmail(Agreement agreement);

        Task<IEnumerable<Agreement>>? GetAllAgreementsByProjectAndEmployer(Agreement agreement);
        Task<IEnumerable<Agreement>>? GetTypesOfProjects(Agreement agreement);
    }
}
