using Microsoft.AspNetCore.Mvc;

using ContosoPizza.API.Models;
using ContosoPizza.API.Services.IServices;
using ContosoPizza.API.Controllers.Abstractions;

namespace ContosoPizza.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToppingController : GenericController<Topping>
{
    public ToppingController(IGenericService<Topping> service) : base(service)
    {

    }
}
