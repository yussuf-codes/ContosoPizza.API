using System.Linq;
using System.Collections.Generic;

using ContosoPizza.API.Models;

namespace ContosoPizza.API.Data;

public static class DbInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        if (context.Pizzas.Any() && context.Toppings.Any() && context.Sauces.Any())
            return;

        Topping pepperoniTopping = new Topping { Name = "Pepperoni", Calories = 90 };
        Topping sausageTopping = new Topping { Name = "Sausage", Calories = 95 };
        Topping hamTopping = new Topping { Name = "Ham", Calories = 70 };
        Topping chickenTopping = new Topping { Name = "Chicken", Calories = 50 };
        Topping pineappleTopping = new Topping { Name = "Pineapple", Calories = 75 };

        Sauce tomatoSauce = new Sauce { Name = "Tomato", IsVegan = true };
        Sauce alfredoSauce = new Sauce { Name = "Alfredo", IsVegan = false };

        List<Pizza> pizzas = new List<Pizza>()
        {
            new Pizza { Name = "Meat Lovers", IsGlutenFree = false, Sauce = tomatoSauce, Toppings = new List<Topping> { pepperoniTopping, sausageTopping, hamTopping, chickenTopping } },
            new Pizza { Name = "Hawaiian", IsGlutenFree = true, Sauce = tomatoSauce, Toppings = new List<Topping> { pineappleTopping, hamTopping } },
            new Pizza { Name = "Alfredo Chicken", IsGlutenFree = false, Sauce = alfredoSauce, Toppings = new List<Topping> { chickenTopping } }
        };

        context.Pizzas.AddRange(pizzas);
        context.SaveChanges();
    }
}
