using Google.Cloud.Firestore;
using System;

namespace Domain.Payments.Entities
{

    [FirestoreData]
    public class PaymentHistory
    {
        [FirestoreProperty]
        public string EmployerEmail { get; set; }
        [FirestoreProperty]
        public string EmployeeEmail { get; set; }
        [FirestoreProperty]
        public string PaymentInterval { get; set; }
        [FirestoreProperty]
        public string ProjectName { get; set; }
        [FirestoreProperty]
        public double GrossSalary { get; set; }
        [FirestoreProperty]
        public string StartDate { get; set; }
        [FirestoreProperty]
        public string EndDate { get; set; }
        [FirestoreProperty]
        public double NetSalary { get; set; }
        [FirestoreProperty]
        public string ContractType { get; set; }
        [FirestoreProperty]
        public string Subscriptions { get; set; }
        [FirestoreProperty]
        public double EmployerTaxes { get; set; }
        [FirestoreProperty]
        public double EmployeeTaxes { get; set; }

        public PaymentHistory(string employerEmail, string employeeEmail, string paymentInterval, string projectName, double grossSalary, string startDate, string endDate, double netSalary, string contractType, string subscriptions, double employerTaxes, double employeeTaxes)
        {
            this.EmployerEmail = employerEmail;
            this.EmployeeEmail = employeeEmail;
            this.PaymentInterval = paymentInterval;
            this.ProjectName = projectName;
            this.GrossSalary = grossSalary;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.NetSalary = netSalary;
            this.ContractType = contractType;
            this.Subscriptions = subscriptions;
            this.EmployerTaxes = employerTaxes;
            this.EmployeeTaxes = employeeTaxes;
        }

        public PaymentHistory() { }

    }
}