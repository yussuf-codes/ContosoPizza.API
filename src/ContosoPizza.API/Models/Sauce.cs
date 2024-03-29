using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.API.Models;

public class Sauce : BaseModel
{
    [MaxLength(256)]
    public string Name { get; set; } = null!;

    public bool IsVegan { get; set; }
}
