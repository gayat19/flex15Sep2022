using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace MyFirstWebApp.Controllers
{
    public class PizzaController : Controller
    {
        //static List<Pizza> pizzas = new List<Pizza>()
        //{
        //    new Pizza{Id=101,Name="Pan Pizza",Price=120.4f,Pic="images/Pic1.jpg"},
        //    new Pizza{Id=102,Name="Veg Extravenzza",Price=450.0f,Pic="images/Pic2.jpg"}
        //};
        //static List<Pizza> cart = new List<Pizza>();
        public async Task<IActionResult> Index()
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                if (token == null)
                {
                    return RedirectToAction("Register", "User");
                }
                using(var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using(var response = await client.GetAsync("http://localhost:5298/api/Pizza"))
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(responseText);
                        return View(pizzas);
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Debug.WriteLine(e.Message);
                return RedirectToAction("Register", "User");
            }
            return RedirectToAction("Register", "User");
        }
        [HttpPost]
        public IActionResult AddToCart(int pid)
        {
            //var pizza = pizzas.FirstOrDefault(p => p.Id == pid);
            //if (pizza == null)
            //    return View();
            //cart.Add(pizza);
            //ViewBag.pizzas = cart;
            return View();
        }
    }
}
