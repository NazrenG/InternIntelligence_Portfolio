using Portfolio.Business.Abstract;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Data;
using Portfolio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Concrete
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;

        public AchievementService(IAchievementRepository achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }

        public async Task AddAchievement(Achievement achievement)
        {
            var check = await _achievementRepository.GetAll(p => p.Created == achievement.Created);
            if (check.Count == 0)
                await _achievementRepository.Add(achievement);
        }

        public async Task DeleteAchievement(int id)
        {
            var item = await _achievementRepository.GetById(p => p.Id == id);
            await _achievementRepository.Delete(item);
        }

        public async Task<Achievement> GetAchievementById(int id)
        {
            return await _achievementRepository.GetById(p => p.Id == id);
        }

        public async Task<List<Achievement>> GetAllAchievements()
        {
            return await _achievementRepository.GetAll();
        }

        public async Task UpdateAchievement(Achievement achievement)
        {
            await _achievementRepository.Update(achievement);
        }
    }
}
