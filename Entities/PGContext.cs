using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PGContext.Entities
{
    public class CylanceContext : DbContext
    {
        public CylanceContext() : base() {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["PostgreSQL"].ToString());
        }

        public DbSet<Guid> Guids { get; set; }
    }
}
