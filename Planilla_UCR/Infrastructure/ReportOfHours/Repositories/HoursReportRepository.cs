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
            DocumentReference reportsReference = _firestoreDbContext.Collection("ReportHoursHistory").Document(report.ProjectName + report.EmployerEmail).
                Collection(report.EmployeeEmail).Document(report.ReportDate);
            await reportsReference.CreateAsync(report);
            _dbContext.HoursReport.Add(report);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<bool> HasReportAsync(HoursReport report)
        {
            bool hasReport = true;
           /* IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where
               (e => e.EmployeeEmail == report.EmployeeEmail && e.EmployerEmail == 
                     report.EmployerEmail && e.ReportDate.Value.Date == report.ReportDate.Value.Date && 
                     e.ProjectName == report.ProjectName).ToListAsync();
            if(reports.Length() == 0)
            {
                hasReport = false;
            }*/
            return hasReport;
        }

        public async Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email)
        {
            IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where
               (e => e.EmployeeEmail == email).ToListAsync();
            return reports;
        }

        public async Task<IList<HoursReport>> GetEmployeeReports(HoursReport hoursReport, DateTime endDate)
        {
            /*IList<HoursReport> reports = await _dbContext.HoursReport.Where
                (e=> e.EmployeeEmail == hoursReport.EmployeeEmail &&
                 (endDate >= e.ReportDate && e.ReportDate >= hoursReport.ReportDate) && e.Approved == 1).ToListAsync();
            return reports;*/
            return null;
        }

        public async Task UpdateReport(HoursReport updateReport)
        {
          //  String reportDate = updateReport.ReportDate.Value.ToShortDateString().Replace("/", "-");
            DocumentReference reportHoursReference = _firestoreDbContext.Collection("ReportHoursHistory").Document(updateReport.ProjectName + updateReport.EmployerEmail).
                Collection(updateReport.EmployeeEmail).Document(updateReport.ReportDate);
            DocumentSnapshot snapshot = await reportHoursReference.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                await reportHoursReference.SetAsync(updateReport);
            }
            else
            {
                Console.WriteLine("Document does not exist!", snapshot.Id);
            }
        }

        public async Task<IEnumerable<HoursReport>> GetProjectHoursReport(string projectName, string employeeEmail, string employerEmail)
        {
            /*IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where(e => e.EmployeeEmail == employeeEmail).ToListAsync();
            reports = reports.Where(e => e.Approved == 0 && e.ProjectName == projectName && e.EmployerEmail == employerEmail);
            reports = reports.OrderByDescending(report => report.ReportDate);
            return reports;*/
            return null;
        }
    }
}
