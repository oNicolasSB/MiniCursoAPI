using Microsoft.AspNetCore.Mvc;

namespace MiniCursoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult Index()
    {
        return Ok("Hello World!");
    }
}
