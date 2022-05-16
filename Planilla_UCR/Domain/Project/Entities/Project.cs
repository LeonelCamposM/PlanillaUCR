using Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Project.Entities
{
    public class Project : AggregateRoot
    {

        public String EmployerEmail { get; }
        public String ProjectName { get; }
        public String ProjectDescription { get; }
        public int MaximumAmountForBenefits { get; }
        public int MaximumBenefitAmount { get; }
        public String PaymentInterval { get; }


        public Project(String Email, String Name,
            String Description, int MaxAmountBenefits,
            int MaxBenefitAmount, String PayInterval)
        {
            EmployerEmail = Email;
            ProjectName = Name;
            ProjectDescription = Description;
            MaximumAmountForBenefits = MaxAmountBenefits;
            MaximumBenefitAmount = MaxBenefitAmount;
            PaymentInterval = PayInterval;

        }
        public Project(String Email, String Name )
        {
            EmployerEmail = Email;
            ProjectName = Name;
            ProjectDescription = "";
            MaximumAmountForBenefits = 0;
            MaximumBenefitAmount = 0;
            PaymentInterval = "";
        }
    }
}
