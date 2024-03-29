using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContosoPizza.API.Models;

public class Topping : BaseModel
{
    [MaxLength(256)]
    public string Name { get; set; } = null!;

    public int Calories { get; set; }

    [JsonIgnore]
    public ICollection<Pizza>? Pizzas { get; set; }
}
