using Microsoft.EntityFrameworkCore;

using ContosoPizza.API.Models;

namespace ContosoPizza.API.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
    public DbSet<Topping> Toppings => Set<Topping>();
}
