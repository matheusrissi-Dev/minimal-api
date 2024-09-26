using MinimalApi.Dominio.Entities;
using MinimalApi.DTOs;
using MminimalAp.Infraestrutura.Db;
using MminimalApi.Dominio.Interfaces;
namespace MinimalApi.Dominio.Servicos
{
    public class AdministradorService : iAdministradorServico{


        private readonly DbContexto _contexto;
        public AdministradorService(DbContexto contexto){
            _contexto = contexto;
        }

        public Administrador Login(LoginDTO loginDTO){
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
               
            
        }
        
    }
}