using Domain.Core.Repositories;
using Infrastructure.Projects;
using Infrastructure.Projects.Repositories;
using Domain.Agreements.Repositories;
using Infrastructure.Agreements;
using Infrastructure.Agreements.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AgreementDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAgreementRepository, AgreementRepository>();

            return services;
        }
    }
}
