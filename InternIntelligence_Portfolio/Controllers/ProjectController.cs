using InternIntelligence_Portfolio.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Entities.Models;

namespace InternIntelligence_Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("NewProject")]
        public async Task<IActionResult> AddProject(AddProjectDto projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest(new { Message = "Invalid Project data!" });
            }

            var item = new Project
            {
                Title = projectDto.Title, 
                Description = projectDto.Description,
                CreatedAt =projectDto.CreatedAt==null?projectDto.CreatedAt: DateTime.UtcNow,
            };
            await projectService.AddProject(item);
            return Ok(item);
        }


        [Authorize]
        [HttpGet("AllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var items = await projectService.GetAllProjects();
            var list = items.Select(i => new ProjectDto
            {
                Title = i.Title, 
                Description = i.Description,
                CreatedAt = i.CreatedAt,
                UpdatedAt = i.UpdatedAt,
            }).ToList();
            return Ok(list);
        }


        [Authorize]
        [HttpGet("ProjectForById/{id}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            var item = await projectService.GetProjectById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Project not found!" });
            }
            var Project = new ProjectDto
            {
                Title = item.Title, 
                Description = item.Description,
                CreatedAt = item.CreatedAt, 
                UpdatedAt = item.UpdatedAt,
            };
            return Ok(Project);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletedProject/{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var item = await projectService.GetProjectById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Project not found!" });
            }

            await projectService.DeleteProject(id);
            return Ok(new { Message = "Project deleted successfully" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatedProject/{id}")]
        public async Task<IActionResult> UpdatedProject(int id,[FromBody] Project dto)

        {
            var project = await projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound(new { Message = "Project not found!" });
            }

            project.Title = dto.Title==""?project.Title:dto.Title;
                project.Description= dto.Description==""?project.Description:dto.Description;
                project.CreatedAt= dto.CreatedAt ;
                project.UpdatedAt= dto.UpdatedAt;
            


            await projectService.UpdateProject(project);
            return Ok(new { Message = "Updated successfully Project" });
        }
    }
}
