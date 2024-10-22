using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Portfolio;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
