using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.DTOs
{
    public class ContractDTO
    {
        public String EmployeeEmail { get; }
        public String ProjectEmail { get; }
        public string ProjectName { get; }
        public int MountPerHour { get; }
        public string TypeOfContract { get; }
        public string Date { get; }
        public int Duration { get; }




        public ContractDTO(String employeeEmail, string projectEmail, string projectName, int mountPerHour, string typeOfContract, string date, int duration)
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
