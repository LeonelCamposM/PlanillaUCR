﻿using Application.People;
using Application.People.Implementations;
using Application.Employees;
using Application.Employees.Implementations;
using Application.Subscriptions;
using Application.Subscriptions.Implementations;
using Application.Accounts;
using Application.Accounts.Implementations;
using Application.Employers;
using Application.Employers.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IEmployerService, EmployerService>();
            return services;
        }
    }
}
