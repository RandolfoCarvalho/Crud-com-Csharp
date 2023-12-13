using Tarefas.Models;

namespace Tarefas.Repositorios.Interfaces
{
    public interface IusuarioRepositorio 
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int Id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int Id);
        Task<bool> Apagar(int Id);

        
    }
}