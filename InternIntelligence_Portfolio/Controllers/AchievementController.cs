using InternIntelligence_Portfolio.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Portfolio.Business.Abstract;
using Portfolio.Entities.Models;

namespace InternIntelligence_Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            this.achievementService = achievementService;
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("NewAchievement")]
        public async Task<IActionResult> AddAchievement(AchievementDto achievementDto)
        {
            if (achievementDto == null)
            {
                return BadRequest(new { Message = "Invalid achievement data!" });
            }

            var item = new Achievement
            {
                Title = achievementDto.Title,
                CertificateUrl = achievementDto.CertificateUrl,
                Description = achievementDto.Description,
                Created = achievementDto.Created,
            };
            await achievementService.AddAchievement(item);
            return Ok(item);
        }


        [Authorize] //admin and user
        [HttpGet("AllAchievements")]
        public async Task<IActionResult> GetAllAchievements()
        {
            var items = await achievementService.GetAllAchievements();
            var list = items.Select(i => new AchievementDto
            {
                Title = i.Title,
                CertificateUrl = i.CertificateUrl,
                Description = i.Description,
                Created = i.Created,
            }).ToList();
            return Ok(list);
        }


        [Authorize]
        [HttpGet("AchievementForById/{id}")]
        public async Task<IActionResult> GetAchievement([FromRoute] int id)
        {
            var item = await achievementService.GetAchievementById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Achievement not found!" });
            }
            var achievement = new AchievementDto
            {
                Title = item.Title,
                CertificateUrl = item.CertificateUrl,
                Description = item.Description,
                Created = item.Created,
            };
            return Ok(achievement);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletedAchievement/{id}")]
        public async Task<IActionResult> DeleteAchievement([FromRoute] int id)
        {
            var item = await achievementService.GetAchievementById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Achievement not found!" });
            }

            await achievementService.DeleteAchievement(id);
            return Ok(new { Message = "Achievement deleted successfully" });
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatedAchievement/{id}")]
        public async Task<IActionResult> UpdatedAchievement(int id, [FromBody] AchievementDto dto)
        {
            var achievement = await achievementService.GetAchievementById(id);
            if (achievement == null)
            {
                return NotFound(new { Message = "Achievement not found!" });
            }

            achievement.Title = dto.Title == "" ? achievement.Title : dto.Title;
            achievement.CertificateUrl = dto.CertificateUrl == "" ? achievement.CertificateUrl : dto.CertificateUrl;
            achievement.Description = dto.Description == "" ? achievement.Description : dto.Description;
            achievement.Created = dto.Created;



            await achievementService.UpdateAchievement(achievement);
            return Ok(new { Message = "Updated successfully achievement" });
        }
    }
}
