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
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public string ProjectName { get; set; }
        public string ContractDate { get; set; }
        public string ContractType { get; set; }
        public int MountPerHour { get; set; }
        public string Duration { get; set; }

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
