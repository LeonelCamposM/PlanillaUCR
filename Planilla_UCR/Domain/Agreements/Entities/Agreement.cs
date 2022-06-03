using System;

namespace Domain.Agreements.Entities
{
    public class Agreement
    {
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public string ContractStartDate { get; set; }
        public String ContractType { get; set; }
        public int MountPerHour { get; set; }
        public string ContractFinishDate { get; set; }


        public Agreement(string employeeEmail, string employerEmail, string projectName, string contractStartDate, string contractType, int mountPerHour, string contractFinishDate)
        {
            this.EmployeeEmail = employeeEmail;
            this.EmployerEmail = employerEmail;
            this.ProjectName = projectName;
            this.ContractStartDate = contractStartDate;
            this.ContractType = contractType;
            this.MountPerHour = mountPerHour;
            this.ContractFinishDate = contractFinishDate;
        }
    }
}
