using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld
{
    public class Data
    {
        public class CityContext : DbContext
        {
            public CityContext(DbContextOptions<CityContext> options) : base(options) { }

            public DbSet<City> Cities { get; set; }
        }
    }
}
