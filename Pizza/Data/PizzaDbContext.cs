using Pizza.Entities;
using Microsoft.EntityFrameworkCore;

namespace Pizza.Data
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Entities.Pizza> Pizzas { get; set; }
        
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
            :base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Entities.Pizza>()
                .HasIndex(p => p.ShortName).IsUnique();
        }
    }
}