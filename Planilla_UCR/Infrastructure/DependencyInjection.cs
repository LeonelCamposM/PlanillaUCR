using Domain.Core.Repositories;
using Infrastructure.Projects;
using Infrastructure.Projects.Repositories;
using Domain.Contracts.Repositories;
using Infrastructure.Contracts;
using Infrastructure.Contracts.Repositories;
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
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddDbContext<ContractDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IContractRepository, ContractRepository>();

            return services;
        }
    }
}
