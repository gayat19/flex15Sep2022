using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPizzaAPI.Models;
using MyPizzaAPI.Services;

namespace MyPizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PizzaController : ControllerBase
    {
        private readonly IRepo<int, Pizza> _pizzaRepo;
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(IRepo<int,Pizza> pizzaRepo,ILogger<PizzaController> logger)
        {
            _pizzaRepo = pizzaRepo;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> Get()
        {
            var pizzas = _pizzaRepo.GetAll();
            if(pizzas==null)
                return NotFound();
            return Ok(pizzas);
        }
        [HttpGet("GetPizzaById")]
        public ActionResult<Pizza> Get(int pid)
        {
            var pizza = _pizzaRepo.Get(pid);
            if (pizza == null)
                return NotFound();
            return Ok(pizza);
        }
        [HttpPost]
        public ActionResult<Pizza> Create(Pizza pizza)
        {
            var newPizza = _pizzaRepo.Add(pizza);
            if (newPizza == null)
                return BadRequest("Could not add pizza");
            return Created("Database Pizza",pizza);
        }
    }
}
