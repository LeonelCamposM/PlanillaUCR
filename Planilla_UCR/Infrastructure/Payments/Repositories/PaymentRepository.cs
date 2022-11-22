using Domain.Core.Repositories;
using Domain.Payments.Entities;
using Domain.Payments.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static System.Linq.Queryable;
using static System.Linq.Enumerable;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Infrastructure.Payments.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _dbContext;
        private readonly FirestoreDb _firestoreDbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public PaymentRepository(PaymentDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
            string filePath = "../Server_Planilla/wwwroot/firebase_key.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDbContext = FirestoreDb.Create("planillaucr-e92dc");
        }

        public async Task AddPayment(PaymentHistory newPayment)
        {
            DocumentReference paymentsReference = _firestoreDbContext.Collection("PaymentHistory").Document();     
            await paymentsReference.SetAsync(newPayment);
        }

        public async Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName)
        {
            IEnumerable<Payment> payments = await _dbContext.Payments.Where(e => e.EmployeeEmail == employeeEmail &&
             e.EmployerEmail == employerEmail && e.ProjectName == projectName).OrderByDescending(pay => pay.EndDate).ToListAsync();
            Payment lastPay = payments.FirstOrDefault();
            return lastPay;
        }

        public async Task<IList<Payment>> GetProjectPayments(Payment payment)
        {
            Query query = _firestoreDbContext.Collection("PaymentHistory").WhereEqualTo("ProjectName", payment.ProjectName)
              .WhereEqualTo("EmployerEmail", payment.EmployerEmail);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            IList<Payment> payments = new List<Payment>();
            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                PaymentHistory newPayment = documentSnapshot.ConvertTo<PaymentHistory>();
                DateTime startDate = Convert.ToDateTime(newPayment.StartDate);
                DateTime endDate = Convert.ToDateTime(newPayment.EndDate);
                bool startDateEqual = startDate == payment.StartDate;
                bool endDateEqual = endDate == payment.EndDate;
                if (startDateEqual && endDateEqual)
                {
                    payments.Add(new Payment(newPayment.EmployeeEmail, newPayment.EmployerEmail, newPayment.ProjectName, newPayment.GrossSalary, startDate, endDate));
                }
            }
            return payments;
        }

        public async Task<IEnumerable<Payment>> GetEmployeePayments(string email)
        {
            Query query = _firestoreDbContext.Collection("PaymentHistory").WhereEqualTo("EmployeeEmail", email);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<Payment> payments = new List<Payment>();
            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                PaymentHistory newPayment = documentSnapshot.ConvertTo<PaymentHistory>();
                DateTime startDate = Convert.ToDateTime(newPayment.StartDate);
                DateTime endDate = Convert.ToDateTime(newPayment.EndDate);
                payments.Add(new Payment(newPayment.EmployeeEmail, newPayment.EmployerEmail, newPayment.ProjectName, newPayment.GrossSalary, startDate, endDate));
            }
            return payments;
        }

        public async Task<IEnumerable<Payment>> GetLastEmployeePayments(string email)
        {
            IEnumerable<Payment> employeePaymentList = await GetEmployeePayments(email);
            IList<Payment> payments = employeePaymentList.ToList();
            return employeePaymentList.OrderByDescending(e=> e.EndDate).Take(10);
        }

        public async Task<IEnumerable<PaymentHistory>> GetEmployerPayments(string email)
        {
            Query query = _firestoreDbContext.Collection("PaymentHistory").WhereEqualTo("EmployerEmail", email);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<PaymentHistory> payments = new List<PaymentHistory>();
            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                PaymentHistory newPayment = documentSnapshot.ConvertTo<PaymentHistory>();
                payments.Add(newPayment);
            }
            return payments;
        }

        public async Task<IEnumerable<Payment>> GetLastEmployerPayments(string email)
        {
            Query query = _firestoreDbContext.Collection("PaymentHistory").WhereEqualTo("EmployerEmail", email);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            List<Payment> payments = new List<Payment>();
            foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
            {
                PaymentHistory newPayment = documentSnapshot.ConvertTo<PaymentHistory>();
                DateTime startDate = Convert.ToDateTime(newPayment.StartDate);
                DateTime endDate = Convert.ToDateTime(newPayment.EndDate);
                payments.Add(new Payment(newPayment.EmployeeEmail, newPayment.EmployerEmail, newPayment.ProjectName, newPayment.GrossSalary, startDate, endDate));
            }
            return payments.OrderByDescending(e=> e.StartDate).Take(10);
        }

        public async Task<IEnumerable<Payment>> GetEmployeeLatestPayments(string email)
        {
            IEnumerable<Payment> employeePaymentList = await GetEmployeePayments(email);
            IList<Payment> payments = employeePaymentList.ToList();
            return employeePaymentList.OrderByDescending(e => e.EndDate).Take(5).ToList();
        }

        public async Task<IList<Payment>> GetAllPaymentsStartAndEndDates(string employerEmail, string projectName) {
            SqlParameter myEmployerEmail = new SqlParameter("@employerEmail", employerEmail);
            SqlParameter myProjectName = new SqlParameter("@projectName", projectName);

            var paymentList = await _dbContext.Payments.FromSqlRaw("EXEC GetAllPaymentsStartAndEndDates {0},{1}",
               myEmployerEmail, myProjectName).ToListAsync();
            return paymentList;
        }

    }
}