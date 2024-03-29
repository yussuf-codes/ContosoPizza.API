using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.API.DTOs.Requests;

public class PutPizzaRequest
{
    public required int Id { get; set; }

    [MaxLength(256)]
    public required string Name { get; set; }

    public required bool IsGlutenFree { get; set; }

    public required int SauceId { get; set; }

    public required ICollection<int> ToppingsId { get; set; }
}
