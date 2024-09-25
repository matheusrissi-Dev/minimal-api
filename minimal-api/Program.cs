using Microsoft.EntityFrameworkCore;
using MinimalApi.DTOs;
using MminimalAp.Infraestrutura.Db;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

app.MapGet("/", () => "Ola mundo");

app.MapPost("/login", (LoginDTO LoginDTO) =>
{
    if (LoginDTO.Email == "adm@teste.com" && LoginDTO.Senha == "123456")
        return Results.Ok("Login com Sucesso");
    else
        return Results.Unauthorized();
});

app.Run();
