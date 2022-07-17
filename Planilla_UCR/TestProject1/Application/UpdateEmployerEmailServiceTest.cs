using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Application.People.Implementations;
using Application.People;
using Application.Employers.Implementations;
using Application.Employers;
using Moq;
using Xunit;
using System;
//Proyectos
using Domain.People.Repositories;
using Domain.People.Entities;
using Domain.Employers.Repositories;
using Domain.Employers.Entities;

namespace Tests.Application
{
    public class UpdateEmployerEmailServiceTest
    {
        private static string Email = "leonel@ucr.ac.cr";

        [Fact]
        public void UpdateEmployerTest()
        {
            //arrange
            var mockEmployerRepository = new Mock<IEmployerRepository>();
            var employerService = new EmployerService(mockEmployerRepository.Object);
            mockEmployerRepository.Setup(repo => repo.UpdateEmployer(Email));

            //act
            employerService.UpdateEmployer(Email);

            //assert
            mockEmployerRepository.Verify(repo => repo.UpdateEmployer(Email), Times.Once);      
        }
    }
}
