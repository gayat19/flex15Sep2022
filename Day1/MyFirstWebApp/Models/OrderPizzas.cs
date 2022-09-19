using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstWebApp.Models
{
    public class OrderPizzas
    {
        public int PizzaId { get; set; }
        public int OrderNumebr { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
        [ForeignKey("OrderNumebr")]
        public Order Order { get; set; }
    }
}
