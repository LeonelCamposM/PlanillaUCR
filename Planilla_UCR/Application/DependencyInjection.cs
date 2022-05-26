using Application.Projects;
using Application.Projects.Implementations;
using Application.Agreements;
using Application.Agreements.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IAgreementService, Agreements.Implementations.AgreementService>();

            return services;
        }
    }
}
