using CSR2026_Exploratory.Models.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace CSR2026_Exploratory.Models
{
    public class CSRDbContext : DbContext
    {
        public CSRDbContext(DbContextOptions<CSRDbContext> option) : base(option)
        {

        }

        public DbSet<Shop> Shop { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("CONNECTIONSTRING");
            }
        }
    }

}
