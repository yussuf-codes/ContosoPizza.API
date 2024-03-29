using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoPizza.API.Models;
using ContosoPizza.API.Services.IServices;
using ContosoPizza.API.Controllers.IControllers;

namespace ContosoPizza.API.Controllers.Abstractions;

public abstract class GenericController<T> : ControllerBase, IController<T> where T : BaseModel
{
    private readonly IGenericService<T> _service;
    public GenericController(IGenericService<T> service)
    {
        _service = service;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Exists(id))
            return NotFound();
        _service.Delete(id);
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        IEnumerable<T> objects = _service.Get();
        return Ok(objects);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        if (!_service.Exists(id))
            return NotFound();
        return Ok(_service.Get(id));
    }

    [HttpPost]
    public IActionResult Post(T obj)
    {
        obj = _service.Add(obj);
        return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, T obj)
    {
        if (id != obj.Id)
            return BadRequest();
        if (!_service.Exists(id))
            return NotFound();
        _service.Update(id, obj);
        return NoContent();
    }
}
