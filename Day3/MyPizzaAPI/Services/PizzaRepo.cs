using MyPizzaAPI.Models;

namespace MyPizzaAPI.Services
{
    public class PizzaRepo : IRepo<int, Pizza>
    {
        readonly private PizzaContext _context;
        private readonly ILogger<PizzaRepo> _logger;

        public PizzaRepo(PizzaContext context,ILogger<PizzaRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Pizza Add(Pizza item)
        {
            try
            {
                _context.Pizzas.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public Pizza Delete(int key)
        {
            var pizza = Get(key);
            if(pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                _context.SaveChanges();
                return pizza;
            }
            return null;
        }

        public Pizza Get(int key)
        {
            var pizza = _context.Pizzas.FirstOrDefault(p => p.Id == key);
            return pizza;
        }

        public ICollection<Pizza> GetAll()
        {
            var pizzas = _context.Pizzas.ToList();
            if (pizzas.Count == 0)
                return null;
            return pizzas;
        }

        public Pizza Update(Pizza item)
        {
            var pizza = Get(item.Id);
            if (pizza != null)
            {
                pizza.Name = item.Name;
                pizza.Price = item.Price;
                pizza.Pic = item.Pic;
                _context.SaveChanges();
                return pizza;
            }
            return null;
        }
    }
}
