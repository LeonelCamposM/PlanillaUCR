using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;
using Application.Subscriptions.Implementations;
using Domain.Subscriptions.Repositories;
using Domain.Subscriptions.Entities;
using LanguageExt;

namespace Tests.Application
{
    public class SubscriptionServiceTest
    {
        [Fact]
        public void GetSubscription()
        {
            List<Subscription> subscriptionsList = new List<Subscription>
            {
                new Subscription("leonel@ucr.ac.cr", "Proyecto 1", "Piscina", "UCR", "Mensualidad de uso de piscinas", 20000.0, 1, 1),
                new Subscription("leonel@ucr.ac.cr", "Proyecto 2", "Gym", "SmartFit", "Mensualidad de uso del gimnasio", 30000.0, 1, 1),
                new Subscription("leonel@ucr.ac.cr", "Proyecto 3", "Amante de libros", "Librería internacional", "Descuentos en la librería internacional", 40000.0, 1, 1),
            };
            string _employerSubscriptionEmail = "leonel@ucr.ac.cr";
            string _projectSubscriptionName = "Proyecto 1";
            string _subscriptionName = "Piscina";

            //arrange
            var mockSubscriptionRepository = new Mock<ISubscriptionRepository>();
            var subscriptionService = new SubscriptionService(mockSubscriptionRepository.Object);
            mockSubscriptionRepository.Setup(repo => repo.GetSubscription(_employerSubscriptionEmail, _projectSubscriptionName, _subscriptionName)).ReturnsAsync(subscriptionsList.Where(
                e => e.EmployerEmail == _employerSubscriptionEmail && e.ProjectName == _projectSubscriptionName && e.SubscriptionName == _subscriptionName).First());

            //act
            var subscription = subscriptionService.GetSubscription(_employerSubscriptionEmail, _projectSubscriptionName, _subscriptionName);

            //assert
            mockSubscriptionRepository.Verify(repo => repo.GetSubscription(_employerSubscriptionEmail, _projectSubscriptionName, _subscriptionName));
            subscription.Should().NotBe(null);
        }
    }
}