using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class SampleController : Controller
    {
        public string Index()
        {
            return "Hello from sample Index";
        }
        public string[] Names()
        {
            return new string[] {  "Ramu", "Bimu","Komu"};
        }

        public ActionResult FirstView()
        {
            User user = new User
            {
                Username = "Tim",
                Password = "123"
            };
            ViewData["user"] = user;
            ViewBag.user = user;
            return View();
        }

        public ActionResult SecondView()
        {
            User user = new User
            {
                Username = "Tim",
                Password = "123"
            };
            return View(user);
        }
    }
}
