using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Agreements.Entities;

namespace Application.Agreements
{
    public interface IAgreementService
    {
        Task CreateAgreementAsync(Agreement agreement);

        Task<Agreement>? GetContracteeByEmail(Agreement agreement);

        Task<IEnumerable<Agreement>>? GetAllAgreementsByProjectAndEmployer(Agreement agreement);

        Task<IEnumerable<Agreement>>? GetTypesOfProjects(Agreement agreement);

    }
}
