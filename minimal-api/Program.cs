using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Servicos;
using MinimalApi.DTOs;
using MminimalAp.Infraestrutura.Db;
using MminimalApi.Dominio.Interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<iAdministradorServico, AdministradorService>();

builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();


app.MapGet("/", () => "Ola mundo");
app.MapPost("/login", ([FromBody] LoginDTO loginDTO, iAdministradorServico administradorServico) =>
{
    if (administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login com Sucesso");
    else
        return Results.Unauthorized();
});

app.Run();
