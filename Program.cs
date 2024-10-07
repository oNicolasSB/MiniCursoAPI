using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MiniCursoAPI.Data;
using MiniCursoAPI.Interfaces;
using MiniCursoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

//adição de controllers
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MiniCurso API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data source=data.db");
}); //adição do serviço do banco de dados

builder.Services.AddScoped<IAlunoService, AlunoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
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