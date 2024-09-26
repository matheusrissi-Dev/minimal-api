using MinimalApi.Dominio.Entities;
using MinimalApi.DTOs;

namespace MminimalApi.Dominio.Interfaces
{
    public interface iAdministradorServico
    {
        Administrador Login(LoginDTO loginDTO);

    }
}