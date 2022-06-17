using System;

namespace Domain.Payments.Entities
{
    public class Payment
    {
        public String EmployeeEmail { get; set; }
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(String employeeEmail, String employerEmail,
            String projectName, DateTime paymentDate)
        {
            EmployeeEmail = employeeEmail;
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            PaymentDate = paymentDate;
        }
    }
}
