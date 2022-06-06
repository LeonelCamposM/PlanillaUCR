using Domain.AgreementTypes.Repositories;
using Domain.AgreementTypes.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.AgreementTypes.Implementations
{
    internal class AgreementTypeService : IAgreementTypeService
    {
        private readonly IAgreementTypeRepository _agreementTypeRepository;

        public AgreementTypeService(IAgreementTypeRepository agreementTypeRepository)
        {
            _agreementTypeRepository = agreementTypeRepository;
        }

        public async Task CreateAgreementTypeAsync(AgreementType agreement)
        {
            await _agreementTypeRepository.CreateAgreementTypeAsync(agreement);
        }


        public async Task<IEnumerable<AgreementType>>? GetTypesOfAgreement(AgreementType agreement)
        {
            return await _agreementTypeRepository.GetTypesOfAgreement(agreement);
        }

    }
}
