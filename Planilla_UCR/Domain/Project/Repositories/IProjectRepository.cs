using Domain.Projects.DTOs;
using Domain.Core.Repositories;
using Domain.Projects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Projects.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<ProjectDTO>> GetAllAsync();
        Task CreateProjectAsync(Project project);
    }
}