using Domain.Projects.DTOs;
using Domain.Projects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Projects
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();
        Task CreateProjectAsync(Project project);
        Task<IEnumerable<Project>> CheckEmployerEmail(string email);
        Task<IEnumerable<Project>> CheckProjectName(string name);
    }
}