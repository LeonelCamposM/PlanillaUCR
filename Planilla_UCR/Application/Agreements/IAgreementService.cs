﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Agreements.Entities;

namespace Application.Agreements
{
    public interface IAgreementService
    {
        Task CreateAgreementAsync(Agreement agreement);
        Task<Agreement>? GetContractee(Agreement agreement);
        Task<IEnumerable<Agreement>> GetEmployeeAgreements(string employeeEmail);
        Task<IEnumerable<Agreement>> GetEmployerAgreements(string employerEmail);

    }
}
