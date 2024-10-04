using Microsoft.AspNetCore.Mvc;

namespace MiniCursoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    [HttpGet]
    public ActionResult RecuperarAlunos()
    {
        return Ok("Hello World!");
    }
}
