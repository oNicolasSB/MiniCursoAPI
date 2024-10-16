using MinicursoAPI.Models;

namespace MinicursoAPI.Interfaces;

public interface IAlunoService
{
    Task<IEnumerable<Aluno>> GetAlunos();
}
