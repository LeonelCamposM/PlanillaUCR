using Google.Cloud.Firestore;
using System;

namespace Domain.Payments.Entities
{
    [FirestoreData]
    public class PaymentHistory
    {

        // Id
        [FirestoreProperty]
        public string employerEmail { get; set; }
        [FirestoreProperty]
        public string employeeEmail { get; set; }
        [FirestoreProperty]
        public string paymentInterval { get; set; }
        [FirestoreProperty]
        public string projectName { get; set; }

        // data
        [FirestoreProperty]
        public double grossSalary { get; set; }
        [FirestoreProperty]
        public string startDate { get; set; }
        [FirestoreProperty]
        public string endDate { get; set; }
        [FirestoreProperty]
        public double netSalary { get; set; }
        [FirestoreProperty]
        public string contractType { get; set; }
        [FirestoreProperty]
        public string subscriptions { get; set; }
        [FirestoreProperty]
        public double employerTaxes { get; set; }
        [FirestoreProperty]
        public double employeeTaxes { get; set; }

        public PaymentHistory(string employerEmail, string employeeEmail, string paymentInterval
,            string projectName, double grossSalary, string startDate, string endDate, double netSalary, string contractType, string subscriptions, double employerTaxes, double employeeTaxes)
        {
            this.employerEmail = employerEmail;
            this.employeeEmail = employeeEmail;
            this.paymentInterval = paymentInterval;
            this.projectName = projectName;
            this.grossSalary = grossSalary;
            this.startDate = startDate;
            this.endDate = endDate;
            this.netSalary = netSalary;
            this.contractType = contractType;
            this.subscriptions = subscriptions;
            this.employerTaxes = employerTaxes;
            this.employeeTaxes = employeeTaxes;
        }

        public PaymentHistory() { }

    }
}