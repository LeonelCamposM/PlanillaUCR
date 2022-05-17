using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Agreements.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Agreements.Entities
{
    public class Agreement
    {
        public String EmployeeEmail { get; }
        public String EmployerEmail { get; }
        public string ProjectName { get; }
        public string ContractDate { get; }
        public string ContractType { get; }
        public int MountPerHour { get; }
        public string Duration { get; }

        public Agreement(String employeeEmail, string employerEmail, string projectName, string contractDate, string contractType, int mountPerHour, string duration)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            MountPerHour = mountPerHour;
            ContractType = contractType;
            ContractDate = contractDate;
            Duration = duration;
        }
    }
}
