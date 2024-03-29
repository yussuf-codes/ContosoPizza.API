using System.Collections.Generic;

namespace ContosoPizza.API.DTOs.Responses;

public class GetPizzasResponse
{
    public required int NumberOfPizzas { get; set; }
    public required ICollection<GetPizzasDTO> Pizzas { get; set; }
}

public class GetPizzasDTO
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required bool IsGlutenFree { get; set; }
}
