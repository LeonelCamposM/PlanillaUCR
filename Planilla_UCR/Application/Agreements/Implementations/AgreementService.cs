using Domain.Core.Repositories;
using Domain.Agreements.DTOs;
using Domain.Agreements.Entities;
using Domain.Agreements.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Agreements.Implementations
{
    internal class AgreementService : IAgreementService
    {
        private readonly IAgreementRepository _agreementRepository;

        public AgreementService(IAgreementRepository agreementRepository) 
        {
            _agreementRepository = agreementRepository;
        }

        public async Task CreateAgreementAsync(Agreement agreement)
        {
            await _agreementRepository.CreateAgreementAsync(agreement);
        }
    }
}
