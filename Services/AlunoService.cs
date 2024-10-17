using Microsoft.EntityFrameworkCore;
using MinicursoAPI.Data;
using MinicursoAPI.Interfaces;
using MinicursoAPI.Models;

namespace MinicursoAPI.Services;

public class AlunoService : IAlunoService
{
    private readonly ApplicationDbContext _context;

    public AlunoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAluno(Aluno aluno)
    {
        _context.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAluno(Aluno aluno)
    {
        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
        return await _context.Alunos.ToListAsync();
    }
    public async Task<Aluno?> GetAluno(int id)
    {
        Aluno? aluno = await _context.Alunos.FindAsync(id);
        return aluno;
    }
    public async Task<IEnumerable<Aluno>> GetAlunosByNome(string nome)
    {
        IEnumerable<Aluno> alunos;
        if (!string.IsNullOrWhiteSpace(nome)) // "" "    " null
        {
            alunos = await _context.Alunos.Where(aluno => aluno.Nome.Contains(nome))
                .ToListAsync();
        }
        else
        {
            alunos = await _context.Alunos.ToListAsync();
        }
        return alunos;
    }
}
