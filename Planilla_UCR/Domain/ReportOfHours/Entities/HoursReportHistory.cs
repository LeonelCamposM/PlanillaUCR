
using Google.Cloud.Firestore;
using System;

namespace Domain.ReportOfHours.Entities
{
    [FirestoreData]
    public class HoursReportHistory
    {
        [FirestoreProperty]
        public String EmployerEmail { get; set; }

        [FirestoreProperty]
        public String ProjectName { get; set; }

        [FirestoreProperty]
        public String EmployeeEmail { get; set; }

        [FirestoreProperty]
        public String ReportDate { get; set; }

        [FirestoreProperty]
        public double ReportHours { get; set; }

        [FirestoreProperty]
        public int Approved { get; set; }

        public HoursReportHistory(String employerEmail, String projectName, String employeeEmail,
            String reportDate, double reportedHours, int approved)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            EmployeeEmail = employeeEmail;
            ReportDate = reportDate;
            ReportHours = reportedHours;
            Approved = approved;    
        }

        public HoursReportHistory()
        {
        }
    }
}
