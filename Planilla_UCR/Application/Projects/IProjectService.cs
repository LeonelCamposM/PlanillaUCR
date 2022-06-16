﻿using Domain.Projects.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Projects
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task CreateProjectAsync(Project project);
        Task<IEnumerable<Project>> GetAllNameProjects(string name);
        Task<Project> GetProject(string employerEmail, string projectName);
        Task<IEnumerable<Project>> GetEmployerProyects(string email);
        bool ModifyProject(Project project, string newProjectName);
    }
}