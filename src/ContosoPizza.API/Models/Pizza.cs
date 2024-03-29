using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContosoPizza.API.Models;

public class Pizza : BaseModel
{
    [MaxLength(256)]
    public string Name { get; set; } = null!;

    public bool IsGlutenFree { get; set; }

    [JsonIgnore]
    public int SauceId { get; set; }
    public Sauce Sauce { get; set; } = null!;

    [NotMapped]
    [JsonIgnore]
    public ICollection<int> ToppingsId { get; set; } = null!;

    public ICollection<Topping> Toppings { get; set; } = null!;
}
