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
    public class ProjectRepository : EFEntityBaseReposiyory<PortfolioDbContext, Project>, IProjectRepository
    {
        public ProjectRepository(PortfolioDbContext context) : base(context)
        {
        }
    }
}
