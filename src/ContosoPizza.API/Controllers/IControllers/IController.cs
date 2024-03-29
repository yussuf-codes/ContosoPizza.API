using Microsoft.AspNetCore.Mvc;

using ContosoPizza.API.Models;

namespace ContosoPizza.API.Controllers.IControllers;

public interface IController<T> where T : BaseModel
{
    IActionResult Delete(int id);
    IActionResult Get();
    IActionResult Get(int id);
    IActionResult Post(T obj);
    IActionResult Put(int id, T obj);
}
