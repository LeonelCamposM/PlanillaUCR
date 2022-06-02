using System;

namespace Domain.Agreements.DTOs
{
    public class AgreementDTO
    {
        public String employeeEmail { get; set; }
        public String employerEmail { get; set; }
        public String projectName { get; set; }
        public DateTime contractStartDate { get; set; }
        public String contractType { get; set; }
        public String mountPerHour { get; set; }
        public DateTime contractFinishDate { get; set; }


        public AgreementDTO(string employeeEmail, string employerEmail, string projectName, DateTime contractStartDate, string contractType, string mountPerHour, DateTime contractFinishDate)
        {
            this.employeeEmail = employeeEmail;
            this.employerEmail = employerEmail;
            this.projectName = projectName;
            this.contractStartDate = contractStartDate;
            this.contractType = contractType;
            this.mountPerHour = mountPerHour;
            this.contractFinishDate = contractFinishDate;
        }
    }
}