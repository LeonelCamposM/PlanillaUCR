﻿using System;

namespace Domain.Agreements.DTOs
{
    public class AgreementDTO
    {
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public String ContractType { get; set; }
        public int MountPerHour { get; set; }
        public DateTime? ContractFinishDate { get; set; }


        public AgreementDTO(string employeeEmail, string employerEmail, string projectName, DateTime? contractStartDate, string contractType, int mountPerHour, DateTime? contractFinishDate)
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