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
    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
        return await _context.Alunos.ToListAsync();
    }
}
