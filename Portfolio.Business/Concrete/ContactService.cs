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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddContactForm(Contact contactForm)
        {

            await _contactRepository.Add(contactForm);
        }

        public async Task DeleteContactForm(int id)
        {
            var item = await _contactRepository.GetById(p => p.Id == id);
            await _contactRepository.Delete(item);
        }

        public async Task<List<Contact>> GetAllContactForms()
        {
            return await _contactRepository.GetAll();
        }

        public Task<Contact> GetContactFormById(int id)
        {
            return _contactRepository.GetById(p => p.Id == id);
        }

        public async Task UpdateContactForm(Contact contactForm)
        {
           await _contactRepository.Update(contactForm);
        }
    }
}
