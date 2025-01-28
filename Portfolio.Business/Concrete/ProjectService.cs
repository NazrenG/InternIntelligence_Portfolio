using Portfolio.Business.Abstract;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task AddProject(Project project)
        {
            var check = await _projectRepository.GetAll(p => p.Title == project.Title);
            if (check.Count == 0)
                await _projectRepository.Add(project);
        }

        public async Task DeleteProject(int id)
        {
            var item = await _projectRepository.GetById(p => p.Id == id);
            await _projectRepository.Delete(item);
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _projectRepository.GetAll();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _projectRepository.GetById(p => p.Id == id);
        }

        public async Task UpdateProject(Project project)
        {
            await _projectRepository.Update(project);
        }
    }
}
