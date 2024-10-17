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
    [HttpGet("AlunoPorNome")]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByNome([FromQuery] string nome)
    {
        try
        {
            IEnumerable<Aluno> alunos = await _alunoService.GetAlunosByNome(nome);
            if (alunos == null || alunos.Count() == 0)
                return NotFound($"Não existem alunos com o critério {nome}.");
            return Ok(alunos);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar alunos");
        }
    }

    [HttpGet("{id:int}", Name = "GetAluno")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
        Aluno? aluno = await _alunoService.GetAluno(id);
        if (aluno == null)
        {
            return NotFound($"Aluno com o id {id} não encontrado.");
        }
        return Ok(aluno);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Aluno aluno)
    {
        aluno.Id = 0;
        await _alunoService.CreateAluno(aluno);
        return Ok();
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] Aluno aluno)
    {
        if (id != aluno.Id)
            return BadRequest("Dados inconsistentes");

        await _alunoService.UpdateAluno(aluno);
        return Ok($"Aluno id {id} atualizado com sucesso.");
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        Aluno? aluno = await _alunoService.GetAluno(id);
        if (aluno == null)
        {
            return NotFound($"Aluno com id {id} não encontrado");
        }
        await _alunoService.DeleteAluno(aluno);
        return Ok($"Aluno id {id} excluído com sucesso.");
    }

}
