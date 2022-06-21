﻿using Domain.Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Agreements.Repositories
{
    public interface IAgreementRepository
    {
        Task CreateAgreementAsync(Agreement agreement);
        Task<Agreement>? GetContractee(Agreement agreement);
        Task<IEnumerable<Agreement?>> GetAllAgreementsByProjectAndEmployer(string projectName, string employerEmail);
        Task<IEnumerable<Agreement>> GetEmployeeProjects(string employeeEmail);
        Task DesactivateAgreement(string employeeEmail, string employerEmail, string projectName, string justification);
        Task<IEnumerable<Agreement>>? CheckAgreementTypeOfContractee(Agreement agreement);

    }
}
