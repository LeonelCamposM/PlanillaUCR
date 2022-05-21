using Application.Projects;
using Application.Projects.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            return services;
        }
    }
}
