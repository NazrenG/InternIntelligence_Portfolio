using Portfolio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Abstract
{
    public interface IProjectService
    {
        public Task AddProject(Project project);
        public Task<List<Project>> GetAllProjects();
        public Task<Project> GetProjectById(int id);
        public Task UpdateProject(Project project);
        public Task DeleteProject(int id);
    }
}
