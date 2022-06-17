﻿using Domain.Core.Repositories;
using Domain.Payments.Entities;
using Domain.Payments.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Payments.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public PaymentRepository(PaymentDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<Payment?> GetEmployeeLastPayment(string employeeEmail, string employerEmail, string projectName)
        {
            IEnumerable<Payment> payments = await _dbContext.Payments.Where(e => e.EmployeeEmail == employeeEmail &&
            e.EmployerEmail == employerEmail && e.ProjectName == projectName).OrderByDescending(pay => pay.PaymentDate).ToListAsync();
            Payment lastPay = payments.FirstOrDefault();
            return lastPay;
        }
    }
}