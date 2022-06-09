﻿using Domain.Core.Repositories;
using Domain.Agreements.Entities;
using Domain.Agreements.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


using System.Linq;

namespace Infrastructure.Agreements.Repositories
{
    internal class AgreementRepository : IAgreementRepository
    {
        private readonly AgreementDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AgreementRepository(AgreementDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateAgreementAsync(Agreement agreement)

        {
            _dbContext.Agreements.Add(agreement);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<Agreement>? GetContracteeByEmail(Agreement agreement)
        {
            IList<Agreement> agreementList = await _dbContext.Agreements.Where
                (e => e.EmployeeEmail == agreement.EmployeeEmail && e.EmployerEmail == agreement.EmployerEmail
                && e.ProjectName == agreement.ProjectName).ToListAsync();
            Agreement myAgreement = null;
            if (agreementList.Length() > 0)
            {
                myAgreement = agreementList.First();
            }
            return myAgreement;

        }
    }
}
