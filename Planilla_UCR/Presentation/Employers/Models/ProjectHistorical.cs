using System;

namespace Presentation.Employers.Models
{
    internal class ProjectHistorical
    {

        public string ProjectName { get; set; }
        public string PaymentFrecuency { get; set; }
        public DateTime PaymentDate { get; set; }
        public double GrossSalary { get; set; }
        public double Benefits { get; set; }
        public double EmployerCharges { get; set; }
        public double ObligatoryDeductions { get; set; }
        public double VoluntaryDeductions { get; set; }
        public double EmployerCost { get; set; }

        public ProjectHistorical()
        {
            ProjectName = String.Empty;
            PaymentFrecuency = String.Empty;
            PaymentDate = DateTime.Now;
            GrossSalary = 0;
            Benefits = 0;
            EmployerCharges = 0;
            ObligatoryDeductions = 0;
            VoluntaryDeductions = 0;
            EmployerCost = 0;
        }

        public ProjectHistorical(string projectName, string paymentFrecuency,
            DateTime paymentDate, double grossSalary, double benefits, double employerCharges,
            double obligatoryDeductions, double voluntaryDeductions, double employerCost)
        {
            ProjectName = projectName;
            PaymentFrecuency = paymentFrecuency;
            PaymentDate = paymentDate;
            GrossSalary = grossSalary;
            Benefits = benefits;
            EmployerCharges = employerCharges;
            ObligatoryDeductions = obligatoryDeductions;
            VoluntaryDeductions = voluntaryDeductions;
            EmployerCost = employerCost;
        }
    }
}