using Microsoft.EntityFrameworkCore;
using MiniCursoAPI.Models;

namespace MiniCursoAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().HasData(
            new Aluno { Id = 1, Nome = "João da Silva", Email = "j@j.com", Idade = 20 },
            new Aluno { Id = 2, Nome = "Maria da Silva", Email = "m@m.com", Idade = 22 }
        );
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Aluno> Alunos { get; set; }
}
