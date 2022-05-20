using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Projects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects.Entities
{
    public class Project
    {
        public String EmployerEmail { set; get; }
        public String ProjectName { set; get; }
        public String ProjectDescription { set; get; }
        public int MaximumAmountForBenefits { set; get; }
        public int MaximumBenefitAmount { set; get; }
        public String PaymentInterval { set; get; }

        public Project(String Email, String Name,
                        String Description, int MaxAmountForBenefits,
                        int MaxBenefitAmount, String PayInterval)
        {
            EmployerEmail = Email;
            ProjectName = Name;
            ProjectDescription = Description;
            MaximumAmountForBenefits = MaxAmountForBenefits;
            MaximumBenefitAmount = MaxBenefitAmount;
            PaymentInterval = PayInterval;
        }

        public Project()
        { }
    }
}
