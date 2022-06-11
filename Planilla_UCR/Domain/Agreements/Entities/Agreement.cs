using System;

namespace Domain.Agreements.Entities
{
    public class Agreement
    {
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public String ContractType { get; set; }
        public int MountPerHour { get; set; }
        public DateTime? ContractFinishDate { get; set; }


        public Agreement(string employeeEmail, string employerEmail, string projectName, DateTime? contractStartDate, string contractType, int mountPerHour, DateTime? contractFinishDate)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            ContractStartDate = contractStartDate;
            ContractType = contractType;
            MountPerHour = mountPerHour;
            ContractFinishDate = contractFinishDate;
        }
    }
}
