using Portfolio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Abstract
{
    public interface ISkillService
    {
        public Task AddSkill(Skill skill);
        public Task<List<Skill>> GetAllSkills();
        public Task<Skill> GetSkillById(int id);
        public Task UpdateSkill(Skill skill);
        public Task DeleteSkill(int id);
    }
}
