using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MiniCursoAPI.Data;
using MiniCursoAPI.Interfaces;
using MiniCursoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

//adição de controllers
builder.Services.AddControllers();

//adição do swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MiniCurso API",
        Version = "v1"
    });
});

//adição do serviço do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data source=data.db");
});

builder.Services.AddScoped<IAlunoService, AlunoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //utilização do swagger em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniCurso API V1");
        options.RoutePrefix = string.Empty;
    });
}

//pipeline da aplicação
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();