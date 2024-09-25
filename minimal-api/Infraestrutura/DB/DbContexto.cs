using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entities;

namespace MminimalAp.Infraestrutura.Db;

public class DbContexto : DbContext
{

    private readonly IConfiguration _configurationAppSetings;
    public DbContexto(IConfiguration configurationAppSetings)
    {
        _configurationAppSetings = configurationAppSetings;
    }

    public DbSet<Administrador> Administradors { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            var strConexao = _configurationAppSetings.GetConnectionString("mysql")?.ToString();
            if (!string.IsNullOrEmpty(strConexao))
            {
                optionsBuilder.UseMySql(
                    strConexao,
                    ServerVersion.AutoDetect(strConexao)
                );
            }

        }



    }
}