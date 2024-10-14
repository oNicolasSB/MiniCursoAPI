using Microsoft.AspNetCore.Mvc;

namespace MinicursoAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult Index()
    {
        return Ok("Hello world!");
    }
}
