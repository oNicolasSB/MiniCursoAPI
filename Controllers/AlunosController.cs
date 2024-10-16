using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using MinicursoAPI.Interfaces;
using MinicursoAPI.Models;

namespace MinicursoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _alunoService;
    public AlunosController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    // [HttpGet]
    // public ActionResult<Aluno> GetAluno()
    // {
    //     Aluno aluno = new Aluno()
    //     {
    //         Id = 1,
    //         Nome = "Nícolas Sanson Bassini",
    //         Email = "email@teste.com",
    //         Idade = 20
    //     };
    //     return Ok(aluno);
    // }
    [HttpGet]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAluno()
    {
        return Ok(await _alunoService.GetAlunos());
    }
}
