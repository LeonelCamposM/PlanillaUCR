using System;
using System.Collections.Generic;

namespace Presentation.Employees.Models
{
    internal class PaymentHistoryModel
    {
        public string ProjectName { get; set; }
        public string ContractType { get; set; }
        public DateTime PaymentDate { get; set; }
        public double GrossSalary { get; set; }
        public double LegalDeductions { get; set; }
        public double VoluntaryDeductions { get; set; }
        public double NetSalary { get; set; }

        public PaymentHistoryModel()
        {
            ProjectName = "";
            ContractType = "";
            PaymentDate = DateTime.Now;
            GrossSalary = 0.0;
            LegalDeductions = 0.0;
            VoluntaryDeductions = 0.0;
            NetSalary = 0.0;
        }

        public PaymentHistoryModel(string projectName, string contractType,
            DateTime paymentDate, double grossSalary, double legalDeductions,
            double voluntaryDeductions, double netSalary)
        {
            ProjectName = projectName;
            ContractType = contractType;
            PaymentDate = paymentDate;
            GrossSalary = grossSalary;
            LegalDeductions = legalDeductions;
            VoluntaryDeductions = voluntaryDeductions;
            NetSalary = netSalary;
        }
    }
}
