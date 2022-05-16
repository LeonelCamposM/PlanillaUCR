using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Contracts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Entities
{
    public class Contract
    {
        public String EmployeeEmail { get; }
        public string ProjectEmail { get; }
        public string ProjectName { get; }
        public int MountPerHour { get; }
        public string TypeOfContract { get; }
        public string Date { get; }
        public int Duration { get; }


        public Contract(String employeeEmail,string projectEmail, string projectName, int mountPerHour, string typeOfContract, string date, int duration)
        {
            EmployeeEmail = employeeEmail;
            ProjectEmail = projectEmail;
            ProjectName = projectName;
            MountPerHour = mountPerHour;
            TypeOfContract = typeOfContract;
            Date = date;
            Duration = duration;
        }

    }
}
