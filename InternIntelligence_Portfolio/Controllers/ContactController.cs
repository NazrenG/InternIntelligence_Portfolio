using InternIntelligence_Portfolio.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.Concrete;
using Portfolio.Entities.Models;

namespace InternIntelligence_Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly MailService _mailService;

        public ContactController(IContactService contactService, MailService mailService)
        {
            _contactService = contactService;
            _mailService = mailService;
        }

        [Authorize(Roles = "User")]
        [HttpPost("NewContact")]
        public async Task<IActionResult> AddContact([FromBody] ContactDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new { Message = "Invalid contact data!" });
            }

            var item = new Contact
            {
                Name = dto.Name,
                Email = dto.Email,
                Message = dto.Message,
            };

            try
            {
                _mailService.SendEmail(dto.Email, $"Hi {dto.Name}, {dto.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Mail sending failed!", Error = ex.Message });
            }

            await _contactService.AddContactForm(item);
            return Ok(new ContactDto { Name = item.Name, Email = item.Email, Message = item.Message });
        }


        [Authorize]
        [HttpGet("AllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var items = await _contactService.GetAllContactForms();
            var list = items.Select(i => new ContactDto
            {
                Name = i.Name,
                Email = i.Email,
                Message = i.Message,
            }).ToList();
            return Ok(list);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ContactForById/{id}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
        {
            var item = await _contactService.GetContactFormById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Contact not found!" });
            }

            return Ok(new ContactDto
            {
                Name = item.Name,
                Email = item.Email,
                Message = item.Message,
            });
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletedContact/{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var item = await _contactService.GetContactFormById(id);
            if (item == null)
            {
                return NotFound(new { Message = "Contact not found!" });
            }

            await _contactService.DeleteContactForm(id);
            return Ok(new { Message = "Contact deleted successfully" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatedContact/{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactDto dto)
        {
            var contact = await _contactService.GetContactFormById(id);
            if (contact == null)
            {
                return NotFound(new { Message = "Contact not found!" });
            }

            contact.Name = dto.Name == "" ? contact.Name : dto.Name;
            contact.Email = dto.Message == "" ? contact.Message : dto.Message;
            contact.Message = dto.Message == "" ? contact.Message : dto.Message;



            await _contactService.UpdateContactForm(contact);
            return Ok(new { Message = "Contact update successfully" });
        }


    }
}
