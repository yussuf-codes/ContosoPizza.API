using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using ContosoPizza.API.Data;
using ContosoPizza.API.Models;
using ContosoPizza.API.Services.IServices;

namespace ContosoPizza.API.Services;

public class PizzaService : IGenericService<Pizza>
{
    private readonly DatabaseContext _context;

    public PizzaService(DatabaseContext context)
    {
        _context = context;
    }

    public Pizza Add(Pizza pizza)
    {
        pizza.Toppings = new List<Topping>();
        foreach (int toppingId in pizza.ToppingsId)
            pizza.Toppings.Add(_context.Toppings.First(obj => obj.Id == toppingId));
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();
        return pizza;
    }

    public void Delete(int id)
    {
        Pizza pizza = _context.Pizzas.First(obj => obj.Id == id);
        _context.Pizzas.Remove(pizza);
        _context.SaveChanges();
    }

    public bool Exists(int id)
    {
        if (_context.Pizzas.FirstOrDefault(obj => obj.Id == id) is null)
            return false;
        return true;
    }

    public IEnumerable<Pizza> Get()
    {
        return _context.Pizzas
                .AsNoTracking()
                .ToList();
    }

    public Pizza Get(int id)
    {
        return _context.Pizzas
                .Include(p => p.Toppings)
                .Include(p => p.Sauce)
                .AsNoTracking()
                .First(obj => obj.Id == id);
    }

    public void Update(int id, Pizza pizza)
    {
        pizza.Toppings = new List<Topping>();
        foreach (int toppingId in pizza.ToppingsId)
            pizza.Toppings.Add(_context.Toppings.First(obj => obj.Id == toppingId));
        Pizza currentPizza = _context.Pizzas.First(obj => obj.Id == id);
        _context.Pizzas.Entry(currentPizza).CurrentValues.SetValues(pizza);
        _context.SaveChanges();
    }
}
