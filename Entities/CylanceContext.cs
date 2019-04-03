using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.IO;

namespace CylanceContext.Entities
{
    public class CylanceDBContext : DbContext
    {
        public CylanceDBContext() : base() {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = ConfigurationManager.ConnectionStrings["PostgreSQL"];
            if (conn == null) // need to manually find the config for Unit Tests 
            {
                var dir = Directory.GetCurrentDirectory();
                var strings = ConfigurationManager.OpenExeConfiguration($"{dir}/cylance-api.dll").ConnectionStrings;
                conn = strings.ConnectionStrings["PostgreSQL"];
            }
            optionsBuilder.UseNpgsql(conn.ToString());
        }

        public DbSet<Guid> Guids { get; set; }
    }
}
