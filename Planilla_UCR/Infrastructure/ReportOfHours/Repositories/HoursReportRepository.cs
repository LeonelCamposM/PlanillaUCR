using Domain.Core.Repositories;
using Domain.ReportOfHours.Repositories;
using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ReportOfHours.Repositories
{
    internal class HoursReportRepository : IHoursReportRepository
    {
        private readonly HoursReportDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public HoursReportRepository(HoursReportDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateReportAsync(HoursReport report)
        {
            _dbContext.HoursReport.Add(report);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<HoursReport>> GetReportsAsync(string email)
        {
            IEnumerable<HoursReport> subscriptionResult = await _dbContext.HoursReport.Where
               (e => e.EmployeeEmail == email).ToListAsync();
            return subscriptionResult;
        }
    }
}
