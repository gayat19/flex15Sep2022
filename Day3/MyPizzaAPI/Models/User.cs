using System.ComponentModel.DataAnnotations;

namespace MyPizzaAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
       
    }
}
