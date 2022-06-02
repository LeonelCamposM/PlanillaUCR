using System;

namespace Domain.Agreements.Entities
{
    public class Agreement
    {
        public String employeeEmail { get; set; }
        public String employerEmail { get; set; }
        public String projectName { get; set; }
        public DateTime contractStartDate { get; set; }
        public String contractType { get; set; }
        public int mountPerHour { get; set; }
        public DateTime contractFinishDate { get; set; }


        public Agreement(string employeeEmail, string employerEmail, string projectName, DateTime contractStartDate, string contractType, int mountPerHour, DateTime contractFinishDate)
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
