using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using ContosoPizza.API.Models;
using ContosoPizza.API.DTOs.Requests;
using ContosoPizza.API.DTOs.Responses;
using ContosoPizza.API.Services.IServices;

namespace ContosoPizza.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IGenericService<Pizza> _pizzaService;
    private readonly IGenericService<Sauce> _sauceService;
    private readonly IGenericService<Topping> _toppingService;

    public PizzaController(IMapper mapper, IGenericService<Pizza> pizzaService, IGenericService<Sauce> sauceService, IGenericService<Topping> toppingService)
    {
        _mapper = mapper;
        _pizzaService = pizzaService;
        _sauceService = sauceService;
        _toppingService = toppingService;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_pizzaService.Exists(id))
            return NotFound();
        _pizzaService.Delete(id);
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        IEnumerable<Pizza> pizzas = _pizzaService.Get();
        ICollection<GetPizzasDTO> pizzaDTOs = _mapper.Map<List<GetPizzasDTO>>(pizzas);
        GetPizzasResponse getPizzasResponse = new() { NumberOfPizzas = pizzaDTOs.Count, Pizzas = pizzaDTOs };
        return Ok(getPizzasResponse);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        if (!_pizzaService.Exists(id))
            return NotFound();
        return Ok(_pizzaService.Get(id));
    }

    [HttpPost]
    public IActionResult Post(PostPizzaRequest request)
    {
        if (!_sauceService.Exists(request.SauceId))
            return BadRequest();
        foreach (int toppingId in request.ToppingsId)
        {
            if (!_toppingService.Exists(toppingId))
                return BadRequest();
        }
        Pizza pizza = _mapper.Map<Pizza>(request);
        pizza = _pizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, PutPizzaRequest request)
    {
        if (!_sauceService.Exists(request.SauceId))
            return BadRequest();
        foreach (int toppingId in request.ToppingsId)
        {
            if (!_toppingService.Exists(toppingId))
                return BadRequest();
        }
        Pizza pizza = _mapper.Map<Pizza>(request);
        _pizzaService.Update(id, pizza);
        return NoContent();
    }
}
