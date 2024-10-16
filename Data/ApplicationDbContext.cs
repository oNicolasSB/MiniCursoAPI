using Microsoft.EntityFrameworkCore;
using MinicursoAPI.Models;

namespace MinicursoAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().HasData(
            new Aluno { Id = 1, Nome = "Nícolas Bassini", Email = "nicolas@email.com", Idade = 21 }
        );
        base.OnModelCreating(modelBuilder);
    }
}
