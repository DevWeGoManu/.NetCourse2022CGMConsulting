using AreaGeografica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace AreaGeografica.Persistance.Configuration
{
    public class DatabaseCxt : DbContext
    {
        public readonly string _connectionString;

        public DatabaseCxt(DbContextOptions<DatabaseCxt> opts, IOptions<AppSettings> setting) : base(opts)
        {
            _connectionString = setting.Value.ConnectionString;
        }
        public DatabaseCxt()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Continents> Continents { get; set; }
 
    }
}