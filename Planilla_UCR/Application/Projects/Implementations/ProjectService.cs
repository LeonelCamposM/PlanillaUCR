using Domain.Projects.DTOs;
using Domain.Projects.Entities;
using Domain.Projects.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Projects.Implementations
{
    internal class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllProjectsAsync();
        }
        public async Task CreateProjectAsync(Project project)
        {
            await _projectRepository.CreateProjectAsync(project);
        }
        public async Task<IEnumerable<Project>> GetEmployerByEmail(string email)
        {
            return await _projectRepository.GetEmployerByEmail(email);
        }
        public async Task<IEnumerable<Project>> GetAllNameProjects(string name)
        {
            return await _projectRepository.GetAllNameProjects(name);
        }
    }
}
