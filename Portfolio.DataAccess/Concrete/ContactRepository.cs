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
    public class ContactRepository : EFEntityBaseReposiyory<PortfolioDbContext, Contact>, IContactRepository
    {
        public ContactRepository(PortfolioDbContext context) : base(context)
        {
        }
    }
}
