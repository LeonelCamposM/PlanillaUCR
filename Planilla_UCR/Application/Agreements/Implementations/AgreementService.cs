using Domain.Agreements.Repositories;
using Domain.Agreements.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Agreements.Implementations
{
    internal class AgreementService : IAgreementService
    {
        private readonly IAgreementRepository _agreementRepository;

        public AgreementService(IAgreementRepository agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }

        public async Task CreateAgreementAsync(string employeeEmail, string employerEmail, string projectName, DateTime contractStartDate, string contractType, int mountPerHour, DateTime contractFinishDate)
        {
            await _agreementRepository.CreateAgreementAsync(employeeEmail, employerEmail, projectName, contractStartDate, contractType, mountPerHour, contractFinishDate);
        }

        public async Task<IEnumerable<Agreement>> GetAgreement(string employeeEmail, string employerEmail, string projectName, DateTime contractStartDate, string contractType, int mountPerHour, DateTime contractFinishDate)
        {
            return await _agreementRepository.GetAgreement(employeeEmail, employerEmail, projectName, contractStartDate, contractType, mountPerHour, contractFinishDate);
        }
    }
}
