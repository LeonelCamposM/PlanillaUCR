﻿using Domain.People.Repositories;
using Domain.People.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Domain.People.DTOs;
using Domain.Core.Repositories;
using System.Collections.Generic;

namespace Application.People.Implementations
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreatePersonAsync(Person personInfo)
        {
            await _personRepository.CreatePersonAsync(personInfo);
        }

        public async Task<IEnumerable<Person>> GetAllEmployees()
        {
            return await _personRepository.GetAllEmployees();
        }

        
        public async  Task<IEnumerable<Person>> GetAllInfoEmployer(Person personInfo)
        {
            return await _personRepository.GetAllInfoEmployer(personInfo);
        }
        
    }
}