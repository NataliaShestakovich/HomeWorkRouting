using HomeWorkRouting.Models.Population.DbModels;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkRouting.DBContext
{
    public class PopulationContext : DbContext
    {
        public PopulationContext(DbContextOptions<PopulationContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
        
    }
}
