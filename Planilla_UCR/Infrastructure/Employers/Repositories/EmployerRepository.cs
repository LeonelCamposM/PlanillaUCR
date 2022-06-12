﻿using Domain.Core.Repositories;
using Domain.Employers.Entities;
using Domain.Employers.Repositories;
using Domain.People.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Employers.Repositories
{
    internal class EmployerRepository : IEmployerRepository
    {
        private readonly EmployerDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public EmployerRepository(EmployerDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateEmployerAsync(String email)
        {
            _dbContext.Add(new Employer(email));
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<Employer>? GetEmployerAsync(String email)
        {
            IList<Employer> employerResult = await _dbContext.Employers.Where
                (e => e.Email == email).ToListAsync();
            Employer employer = null;
            if (employerResult.Length() > 0)
            {
                employer = employerResult.First();
            }
            return employer;
        }

        public async Task<Person?> GetInfoEmployer(Person personInfo)
        {
            IList<Person> employerInfoResult = await _dbContext.People.FromSqlRaw("EXEC GetInfoPerson @EmailPerson",
                  new SqlParameter("@EmailPerson", personInfo.Email)).ToListAsync();
            Person employerInfo = null;
            if (employerInfoResult.Length() > 0)
            {
                employerInfo = employerInfoResult.First();
            }
            return employerInfo;
        }
    }
}