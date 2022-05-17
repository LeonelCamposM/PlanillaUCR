using Application.Projects;
using Application.Projects.Implementations;
using Application.Agreements;
using Application.Agreements.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            //services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IAgreementService, Agreements.Implementations.AgreementService>();

            return services;
        }
    }
}
