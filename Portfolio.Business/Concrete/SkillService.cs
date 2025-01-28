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
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task AddSkill(Skill skill)
        {
            var check = await _skillRepository.GetAll(p => p.Name == skill.Name);
            if (check.Count == 0)
                await _skillRepository.Add(skill);
        }

        public async Task DeleteSkill(int id)
        {
            var item = await _skillRepository.GetById(p => p.Id == id);
            await _skillRepository.Delete(item);
        }

        public async Task<List<Skill>> GetAllSkills()
        {
            return await _skillRepository.GetAll();
        }

        public async Task<Skill> GetSkillById(int id)
        {
            return await _skillRepository.GetById(p => p.Id == id);
        }

        public async Task UpdateSkill(Skill skill)
        {
            await _skillRepository.Update(skill);
        }
    }
}
