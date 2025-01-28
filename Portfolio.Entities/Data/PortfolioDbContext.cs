using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Entities.Models;

namespace Portfolio.Entities.Data
{
    public class PortfolioDbContext : IdentityDbContext<User, Role, string>
    {
        public PortfolioDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
    }
}
