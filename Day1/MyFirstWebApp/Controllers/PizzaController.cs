using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class PizzaController : Controller
    {
        static List<Pizza> pizzas = new List<Pizza>()
        {
            new Pizza{Id=101,Name="Pan Pizza",Price=120.4f,Pic="images/Pic1.jpg"},
            new Pizza{Id=102,Name="Veg Extravenzza",Price=450.0f,Pic="images/Pic2.jpg"}
        };
        static List<Pizza> cart = new List<Pizza>();
        public IActionResult Index()
        {
            return View(pizzas);
        }
        [HttpPost]
        public IActionResult AddToCart(int pid)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Id == pid);
            if (pizza == null)
                return View();
            cart.Add(pizza);
            ViewBag.pizzas = cart;
            return View();
        }
    }
}
