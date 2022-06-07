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

        public async Task<IEnumerable<AgreementType>>? GetTypesOfAgreement()
        {
            return await _agreementTypeRepository.GetTypesOfAgreement();
        }

        public async Task<IEnumerable<AgreementType>>? GetSalaryPerAgreement(string typeOfAgreement)
        {
            return await _agreementTypeRepository.GetSalaryPerAgreement(typeOfAgreement);
        }
    }
}
