using Microsoft.AspNetCore.Mvc;

using ContosoPizza.API.Models;
using ContosoPizza.API.Services.IServices;
using ContosoPizza.API.Controllers.Abstractions;

namespace ContosoPizza.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SauceController : GenericController<Sauce>
{
    public SauceController(IGenericService<Sauce> service) : base(service)
    {

    }
}
