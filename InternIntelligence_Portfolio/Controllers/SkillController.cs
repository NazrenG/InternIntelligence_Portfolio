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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("NewSkill")]
        public async Task<IActionResult> AddSkill(SkillDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new { Message = "Invalid Skill data!" });
            }

            var item = new Skill
            {

                Name = dto.Name,
                Category = dto.Category,
                Level = dto.Level,
            };
            await skillService.AddSkill(item);
            return Ok(item);
        }

        [Authorize]
        [HttpGet("AllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var items = await skillService.GetAllSkills();
            var list = items.Select(i => new SkillDto
            {
                Name = i.Name,
                Category = i.Category,
                Level = i.Level,
            }).ToList();
            return Ok(list);
        }

        [Authorize]
        [HttpGet("SkillForById/{id}")]
        public async Task<IActionResult> GetSkill([FromRoute] int id)
        {
            var item = await skillService.GetSkillById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Skill not found!" });
            }
            var Skill = new SkillDto
            {
                Name = item.Name,
                Category = item.Category,
                Level = item.Level,
            };
            return Ok(Skill);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletedSkill/{id}")]
        public async Task<IActionResult> DeleteSkill([FromRoute] int id)
        {
            var item = await skillService.GetSkillById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Skill not found!" });
            }

            await skillService.DeleteSkill(id);
            return Ok(new { Message = "Skill deleted successfully" });
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatedSkill/{id}")]
        public async Task<IActionResult> UpdatedSkill(int id, [FromBody] SkillDto dto)
        {
            var skill = await skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound(new { Message = "Skill not found!" });
            }

            skill.Name = dto.Name==""?skill.Name:dto.Name;
            skill.Category = dto.Category==""?skill.Category:dto.Category;
            skill.Level = dto.Level == "" ? skill.Level : dto.Level;



            await skillService.UpdateSkill(skill);
            return Ok(new { Message = "Updated successfully Skill" });
        }
    }
}
