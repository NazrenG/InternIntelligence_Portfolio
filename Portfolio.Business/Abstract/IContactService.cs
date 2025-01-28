using Portfolio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Abstract
{
    public interface IContactService
    {
        public Task AddContactForm(Contact contactForm);
        public Task<List<Contact>> GetAllContactForms();
        public Task<Contact> GetContactFormById(int id);
        public Task DeleteContactForm(int id);
        public Task UpdateContactForm(Contact contactForm);
    }
}
