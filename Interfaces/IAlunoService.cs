using MinicursoAPI.Models;

namespace MinicursoAPI.Interfaces;

public interface IAlunoService
{
    Task<IEnumerable<Aluno>> GetAlunos();
    Task CreateAluno(Aluno aluno);
    Task UpdateAluno(Aluno aluno);
    Task DeleteAluno(Aluno aluno);
    Task<Aluno?> GetAluno(int id);
    Task<IEnumerable<Aluno>> GetAlunosByNome(string nome);
}
