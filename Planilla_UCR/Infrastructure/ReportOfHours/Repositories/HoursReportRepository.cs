using Domain.Core.Repositories;
using Domain.ReportOfHours.Repositories;
using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;
using System.Collections.Generic;
using static System.Linq.Queryable;
using static System.Linq.Enumerable;
using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.ReportOfHours.Repositories
{
    internal class HoursReportRepository : IHoursReportRepository
    {
        private readonly HoursReportDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly FirestoreDb _firestoreDbContext;

        public HoursReportRepository(HoursReportDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
            string filePath = "../Server_Planilla/wwwroot/firebase_key.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDbContext = FirestoreDb.Create("planillaucr-e92dc");
        }

        public async Task CreateReportAsync(HoursReport report)
        {
            DocumentReference reportsReference = _firestoreDbContext.Collection("ReportHoursHistory").Document();
            await reportsReference.CreateAsync(report);
            _dbContext.HoursReport.Add(report);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<bool> HasReportAsync(HoursReport report)
        {
            bool hasReport = true;
            
            Query reportHoursReference = _firestoreDbContext.Collection("ReportHoursHistory")
                .WhereEqualTo("EmployeeEmail", report.EmployeeEmail)
                .WhereEqualTo("EmployerEmail", report.EmployerEmail)
                .WhereEqualTo("ProjectName", report.ProjectName)
                .WhereEqualTo("ReportDate", report.ReportDate);
            QuerySnapshot snapshot = await reportHoursReference.GetSnapshotAsync();

            if (snapshot.Count() == 0)
            {
                hasReport = false;
            }

            return hasReport;
        }

        public async Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email)
        {
            Query reportHoursReference = _firestoreDbContext.Collection("ReportHoursHistory")
                .WhereEqualTo("EmployeeEmail", email);
            QuerySnapshot snapshot = await reportHoursReference.GetSnapshotAsync();

            IList<HoursReport> report = new List<HoursReport>();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                HoursReport hourReport = documentSnapshot.ConvertTo<HoursReport>();
                report.Add(hourReport);
            }
            return report;
        }

        public async Task<IList<HoursReport>> GetEmployeeReports(HoursReport hoursReport, DateTime endDate)
        {
            Query reportHoursReference = _firestoreDbContext.Collection("ReportHoursHistory")
                .WhereEqualTo("EmployeeEmail", hoursReport.EmployeeEmail)
                .WhereEqualTo("Approved", 1);
            QuerySnapshot snapshot = await reportHoursReference.GetSnapshotAsync();

            IList<HoursReport> report = new List<HoursReport>();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                HoursReport hourReport = documentSnapshot.ConvertTo<HoursReport>();
                DateTime hourReportDate = Convert.ToDateTime(hourReport.ReportDate);
                DateTime hoursReportDate = Convert.ToDateTime(hoursReport.ReportDate);
                if (hourReportDate <= endDate && hourReportDate >= hoursReportDate)
                {
                    report.Add(hourReport);
                }
            }
            return report;
        }

        public async Task UpdateReport(HoursReport updateReport)
        {
            CollectionReference reportHoursReference = _firestoreDbContext.Collection("ReportHoursHistory");
            Query query = reportHoursReference
                 .WhereEqualTo("EmployeeEmail", updateReport.EmployeeEmail)
                 .WhereEqualTo("EmployerEmail", updateReport.EmployerEmail)
                 .WhereEqualTo("ProjectName", updateReport.ProjectName)
                 .WhereEqualTo("ReportDate", updateReport.ReportDate);
          
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            //await reportHoursReference.Document(snapshot.Documents.First().Id).SetAsync(updateReport);
        }

        public async Task<IEnumerable<HoursReport>> GetProjectHoursReport(string projectName, string employeeEmail, string employerEmail)
        {
            Query reportHoursReference = _firestoreDbContext.Collection("ReportHoursHistory")
                .WhereEqualTo("EmployeeEmail", employeeEmail)
                .WhereEqualTo("EmployerEmail", employerEmail)
                .WhereEqualTo("ProjectName", projectName)
                .WhereEqualTo("Approved", 0);
            QuerySnapshot snapshot = await reportHoursReference.GetSnapshotAsync();

            IList<HoursReport> report = new List<HoursReport>();

            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                HoursReport hourReport = documentSnapshot.ConvertTo<HoursReport>();
                report.Add(hourReport);
            }
            return report;
        }
    }
}
