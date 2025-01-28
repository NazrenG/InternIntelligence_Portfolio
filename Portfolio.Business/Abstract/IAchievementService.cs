using Portfolio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Abstract
{
    public interface IAchievementService
    {
        public Task AddAchievement(Achievement achievement);
        public Task<List<Achievement>> GetAllAchievements();
        public Task<Achievement> GetAchievementById(int id);
        public Task UpdateAchievement(Achievement achievement);
        public Task DeleteAchievement(int id);
    }
}
