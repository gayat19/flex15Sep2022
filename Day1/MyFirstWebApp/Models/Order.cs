using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstWebApp.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public string Username { get; set; }
        public float TotalAmount { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }//Will not be present in the table

        [ForeignKey("Username")]
        public User User { get; set; }

        public ICollection<OrderPizzas> OrdersPizzas { get; set; }
    }
}
