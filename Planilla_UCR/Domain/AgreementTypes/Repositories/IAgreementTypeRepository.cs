using Domain.AgreementTypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.AgreementTypes.Repositories
{
    public interface IAgreementTypeRepository
    {
        Task CreateAgreementTypeAsync(AgreementType agreement);

        Task<IEnumerable<AgreementType>>? GetTypesOfAgreement(AgreementType agreement);

        Task<IEnumerable<AgreementType>>? GetSalaryPerAgreement(string typeOfAgreement, int salary);
        //Task<IEnumerable<AgreementType>> GetAgreement(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate);
    }
}
