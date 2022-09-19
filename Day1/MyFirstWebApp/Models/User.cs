using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApp.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
