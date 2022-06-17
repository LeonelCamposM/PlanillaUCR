using System;

namespace Presentation.Agreements.Models
{
    internal class JoinedTables
    {
        public string EmployerEmail { get; set; }
        public string ProjectName { get; set; }
        public string PaymentInterval { get; set; }
        public string EmployeeEmail { get; set; }
        public string ContractType { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractFinishDate { get; set; }
        public int MountPerHour { get; set; }

        public JoinedTables() {
            this.EmployerEmail = "";
            this.ProjectName = "";
            this.PaymentInterval = "";
            this.EmployeeEmail = "";
            this.ContractType = "";
            this.ContractStartDate = DateTime.Now;
            this.ContractFinishDate = DateTime.Now;
            this.MountPerHour = 0;
        }

        public JoinedTables(string EmployerEmail, string ProjectName, string PaymentInterval, string EmployeeEmail, string ContractType, DateTime ContractStartDate, DateTime ContractFinishDate, int MountPerHour)
        {
            this.EmployerEmail = EmployerEmail;
            this.ProjectName = ProjectName;
            this.PaymentInterval = PaymentInterval; 
            this.EmployeeEmail = EmployeeEmail;
            this.ContractType = ContractType;
            this.ContractStartDate = ContractStartDate;
            this.ContractFinishDate = ContractFinishDate;
            this.MountPerHour = MountPerHour;
        }
    }
}