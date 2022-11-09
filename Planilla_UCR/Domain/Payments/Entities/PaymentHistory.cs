using Google.Cloud.Firestore;
using System;

namespace Domain.Payments.Entities
{
    [FirestoreData]
    public class PaymentHistory
    {
        [FirestoreProperty]
        public string EmployeeEmail { get; set; }
        [FirestoreProperty]
        public string EmployerEmail { get; set; }
        [FirestoreProperty]
        public string ProjectName { get; set; }
        [FirestoreProperty]
        public double GrossSalary { get; set; }
        [FirestoreProperty]
        public string StartDate { get; set; }
        [FirestoreProperty]
        public string EndDate { get; set; }

        public PaymentHistory(string employeeEmail, string employerEmail,
            string projectName, double grossSalary, string startDate, string endDate)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            GrossSalary = grossSalary;
        }

        public PaymentHistory() { }

    }
}