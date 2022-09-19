using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApp.Models
{
    public class PizzaStroreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-86CRKFR\SQLEXPRESS;Integrated security=true;Initial Catalog=dbPS16Sep2022");
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPizzas> OrderPizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 101, Name = "Pan Pizza", Price = 120.4f, Pic = "images/Pic1.jpg" },
            new Pizza { Id = 102, Name = "Veg Extravenzza", Price = 450.0f, Pic = "images/Pic2.jpg" }
                );
            modelBuilder.Entity<OrderPizzas>().HasKey(op =>
            new
            {
                op.PizzaId,
                op.OrderNumebr
            });
        }

    }
}
