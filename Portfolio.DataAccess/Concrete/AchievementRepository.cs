using Portfolio.Core.DataAccess.EntityFramework;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Data;
using Portfolio.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Concrete
{
    public class AchievementRepository : EFEntityBaseReposiyory<PortfolioDbContext, Achievement>, IAchievementRepository
    {
        public AchievementRepository(PortfolioDbContext context) : base(context)
        {
        }
    }
}
