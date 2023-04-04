using AlfRedDoe_Pizza.Models;
using AlfRedDoe_Pizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlfRedDoe_Pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController :ControllerBase
{
    public PizzaController()
    {

    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();
        
        return pizza;
    }

    // POST action

    // PUT action

    // DELETE action
}
