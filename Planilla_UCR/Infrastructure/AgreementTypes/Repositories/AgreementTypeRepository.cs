using Domain.Core.Repositories;
using Domain.AgreementTypes.Entities;
using Domain.AgreementTypes.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


using System.Linq;

namespace Infrastructure.AgreementTypes.Repositories
{
    internal class AgreementTypeRepository : IAgreementTypeRepository
    {
        private readonly AgreementTypeDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AgreementTypeRepository(AgreementTypeDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateAgreementTypeAsync(AgreementType agreement)

        {
            _dbContext.AgreementTypes.Add(agreement);
            await _dbContext.SaveEntitiesAsync();
        }
  
        public async Task<IEnumerable<AgreementType>>? GetTypesOfAgreement(AgreementType agreement) 
        { 
            // TODO Look for better names && test it
            IList<AgreementType> agreementTpeList = await _dbContext.AgreementTypes.Where
                (e => e.TypeAgreement == agreement.TypeAgreement && e.MountPerHour == agreement.MountPerHour).ToListAsync();
            AgreementType agreementAux = null;
            if (agreementTpeList.Length() > 0)
            {
                agreementAux = agreementTpeList.First();
            }
            return agreementTpeList;
        }





    }
}
