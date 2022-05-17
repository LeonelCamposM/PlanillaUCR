using Domain.Projects.Entities;
using System.Threading.Tasks;
using Domain.Core.Repositories;


namespace Domain.Projects.Repositories
{
    public interface IProjectRepository 
    {
        Task CreateProjectAsync<ProjectDTO (Project projectInfo);
    }
}
