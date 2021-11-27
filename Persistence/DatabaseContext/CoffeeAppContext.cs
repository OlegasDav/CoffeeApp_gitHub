using Microsoft.EntityFrameworkCore;
using Persistence.DataAccess;
using Persistence.Entities;

namespace Persistence.DatabaseContext
{
    public class CoffeeAppContext : DbContext
    {
        public CoffeeAppContext(DbContextOptions<CoffeeAppContext> options) : base(options)
        {
        }

        public DbSet<Coffee> Coffee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new CoffeeConfiguration());
        }
    }
}
