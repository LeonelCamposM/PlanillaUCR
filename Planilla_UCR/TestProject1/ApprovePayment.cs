using Application.Payments.Implementations;
using Domain.Agreements.Entities;
using Domain.Payments.Entities;
using Domain.Projects.Entities;
using Domain.ReportOfHours.Entities;
using Domain.Subscribes.Entities;
using Domain.Subscriptions.Entities;
using Presentation.Payments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.PaymentCalculator.Implementations;

namespace Tests.PaymentTest
{
    public class EmployeeAgreement
    {
        public string ProjectName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName1 { get; set; }
        public string EmployeeLastName2 { get; set; }
        public string FullName { get; set; }
        public string ContractType { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractFinishDate { get; set; }
        public int MountPerHour { get; set; }
        public double MountToPay { get; set; }

        public EmployeeAgreement()
        {
            ProjectName = "";
            EmployeeEmail = "";
            EmployeeName = "";
            EmployeeLastName1 = "";
            EmployeeLastName2 = "";
            ContractType = "";
            ContractStartDate = DateTime.Now;
            ContractFinishDate = DateTime.Now;
            MountPerHour = 0;
            MountToPay = 0.0;
        }

        public EmployeeAgreement(string projectName, string employeeEmail, string employeeName,
            string employeeLastName1, string employerLastName2, string contractType,
            DateTime contractStartDate, DateTime contractFinishDate, int mountPerHour,
            double mountToPay)
        {
            ProjectName = projectName;
            EmployeeName = employeeName;
            EmployeeLastName1 = employeeLastName1;
            EmployeeLastName2 = employerLastName2;
            ContractType = contractType;
            ContractStartDate = contractStartDate;
            ContractFinishDate = contractFinishDate;
            MountPerHour = mountPerHour;
            MountToPay = mountToPay;
        }
    }
        public class ProjectModel
        {
        public string ProjectName { get; set; }
        public string EmployerEmail { get; set; }
        public string PaymentInterval { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public int DayInterval { get; set; }
        public double MountToPay { get; set; }
        private IList<EmployeeAgreement> EmployeeList { get; set; }

        public ProjectModel()
        {
            ProjectName = "";
            EmployerEmail = "";
            PaymentInterval = "";
            LastPaymentDate = DateTime.Now;
            DayInterval = 0;
            MountToPay = 0.0;
            EmployeeList = null;
        }

        public ProjectModel(string projectName, string employerName,
            string paymentInterval, DateTime lastPaymentDate, int dayInterval,
            double mountToPay, IList<EmployeeAgreement> _employeeList)
        {
            ProjectName = projectName;
            EmployerEmail = employerName;
            PaymentInterval = paymentInterval;
            LastPaymentDate = lastPaymentDate;
            DayInterval = dayInterval;
            MountToPay = mountToPay;
            EmployeeList = _employeeList;
        }
    }

    public class ApprovePayment
    {
        public  IList<Project> _projects { get; set; }
        public  DateTime _nextPay { get; set; }
        private  IList<ProjectModel> _projectsList { get; set; }
        private IList<ProjectModel> _projectsToDelete { get; set; }
        public PaymentCalculatorService paymentService { get; set; }


        public ApprovePayment(IList<Project> projects,
                                      IList<ProjectModel> projectsList,
                                      IList<ProjectModel> projectsToDelete)
        {
            _nextPay = DateTime.Now;
            _projectsToDelete = projectsToDelete;
            _projectsList = projectsList;
            _projects = projects;
            paymentService = new PaymentCalculatorService();

        }

        public async Task GetProjectsToPay()
        {
            foreach (Project _project in _projects)
            {
                var _daysInterval = GetDaysInterval(_project.PaymentInterval, _project.LastPaymentDate);
                if (_project.LastPaymentDate.AddDays(_daysInterval) <= _nextPay)
                {

                    ProjectModel _projectModel = new ProjectModel(_project.ProjectName, _project.EmployerEmail,
                        _project.PaymentInterval, _project.LastPaymentDate,
                        GetDaysInterval(_project.PaymentInterval, _project.LastPaymentDate), 0, new List<EmployeeAgreement>());
                    _projectsList.Add(_projectModel);
                }
            }


        }

        public int GetDaysInterval(string paymentInterval, DateTime lastPaymentDate)
        {
            int _days = 0;

            switch (paymentInterval)
            {
                case "Semanal":
                    {
                        _days = 7;
                    }
                    break;
                case "Bisemanal":
                    {
                        _days = 15;
                    }
                    break;
                case "Quincenal":
                    {
                        _days = fortnightDays(lastPaymentDate);
                    }
                    break;
                case "Mensual":
                    {
                        DateTime nextMonth = lastPaymentDate.AddMonths(1);
                        TimeSpan t = nextMonth - lastPaymentDate;
                        _days = t.Days;
                    }
                    break;

            }
            return _days;
        }


        private int fortnightDays(DateTime lastPaymentDate)
        {
            int _days = 0;
            if (lastPaymentDate.Day == 14)
            {
                _days = 14;
            }
            else
            {
                if (lastPaymentDate.Day == 28)
                {
                    DateTime nextFortnight = lastPaymentDate.AddMonths(1);
                    nextFortnight = nextFortnight.AddDays(-14);
                    TimeSpan t = nextFortnight - lastPaymentDate;
                    _days = t.Days;
                }
                else
                {
                    if (lastPaymentDate.Day < 14)
                    {
                        _days = 14 - lastPaymentDate.Day;
                    }
                    else
                    {
                        _days = 28 - lastPaymentDate.Day;
                    }
                }
            }
            return _days;
        }

        private async Task<double> GetWorkedHours(Agreement agreement, int daysInterval, DateTime lastPaymentDate, IList<HoursReport> reports)
        {
            HoursReport _report = new HoursReport();
            double _workedHours = 0;
            _report.EmployeeEmail = agreement.EmployeeEmail;
            _report.ReportDate = lastPaymentDate;
            foreach (HoursReport hours in reports)
            {
                _workedHours += hours.ReportHours;
            }
            return _workedHours;
        }

        public async Task<double> GetSalary(Agreement agreement, int daysInterval, DateTime lastPaymentDate, IEnumerable<Subscription> subscriptions, IList<HoursReport> reports)
        {
            double salary = await GetSalaryByType(agreement, daysInterval, lastPaymentDate, reports);
            double appliedBenefits = await GetEmployeeBenefits(agreement, daysInterval, lastPaymentDate, subscriptions);
            salary += appliedBenefits;
            return salary;
        }

        private async Task<double> GetSalaryByType(Agreement agreement, int daysInterval, DateTime lastPaymentDate, IList<HoursReport> reports)
        {
            int workedDays = GetWorkedDays(agreement.EmployeeEmail, (DateTime)agreement.ContractStartDate, daysInterval);
            double grossSalary = 0;
            if (agreement.ContractType == "Tiempo completo")
            {
                grossSalary = paymentService.GetFullTimeSalary(agreement.MountPerHour, workedDays);
            }
            if (agreement.ContractType == "Medio tiempo")
            {
                grossSalary = paymentService.GetPartTimeSalary(agreement.MountPerHour, workedDays);
            }
            if (agreement.ContractType == "Servicios profesionales")
            {
                double workedHours = await GetWorkedHours(agreement, daysInterval, lastPaymentDate, reports);
                grossSalary = paymentService.GetSalaryPerHours(agreement.MountPerHour, workedHours);
            }
            return grossSalary;
        }

        private async Task<double> GetEmployeeBenefits(Agreement agreement, int daysInterval, DateTime lastPaymentDate, IEnumerable<Subscription> subscriptions)
        {
            double mountOfBenefits = 0;
            foreach (Subscription _subscription in subscriptions.Where(e => e.TypeSubscription == 1))
            {
                mountOfBenefits += _subscription.Cost;
            }
            return mountOfBenefits;
        }

        public int GetWorkedDays(string employeeEmail, DateTime startDate, int daysInterval)
        {
            DateTime _nextPayment = startDate.AddDays(daysInterval);
            int _workedDays = Convert.ToInt32(daysInterval);
            if (startDate.Month == _nextPayment.Month)
            {
                _workedDays = (_nextPayment - startDate).Days;
            }
            int _workedWeeks = _workedDays / 7;
            _workedDays -= _workedWeeks;
            if (startDate.Date > _nextPayment.Date)
            {
                _workedDays = 0;
            }
            return _workedDays;
        }
    }
}
