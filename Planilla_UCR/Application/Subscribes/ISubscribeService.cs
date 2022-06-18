using Domain.Subscribes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Subscribes
{
    public interface ISubscribeService
    {
        void CreateSubscribe(Subscribe subscription, int typeSubscription);
        Task<IEnumerable<Subscribe>> GetEmployeesBySubscription(string employerEmail, string projectName, string subscriptionName);
        Task<IEnumerable<Subscribe>> GetDeductionsByEmployee(string employeeEmail, string projectName);
        Task<IEnumerable<Subscribe>> GetBenefitsByEmployee(string employeeEmail, string projectName);
        void DeleteSubscribe(Subscribe subscription);
    }
}