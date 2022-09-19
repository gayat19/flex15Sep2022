using Microsoft.EntityFrameworkCore;

namespace MyPizzaAPI.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 101, Name = "Pan Pizza", Price = 120.4f, Pic = "images/Pic1.jpg" },
                new Pizza { Id = 102, Name = "Veg Extravenzza", Price = 450.0f, Pic = "images/Pic2.jpg" }
            );
        }
    }
}
