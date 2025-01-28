using Portfolio.Core.DataAccess.EntityFramework;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Data;
using Portfolio.Entities.Models;

namespace Portfolio.DataAccess.Concrete
{
    public class SkillRepository : EFEntityBaseReposiyory<PortfolioDbContext, Skill>, ISkillRepository
    {
        public SkillRepository(PortfolioDbContext context) : base(context)
        {
        }
    }
}
