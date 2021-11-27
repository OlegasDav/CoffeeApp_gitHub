using Microsoft.EntityFrameworkCore;
using Persistence.DataAccess;
using Persistence.Entities;

namespace Persistence.DatabaseContext
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options)
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
