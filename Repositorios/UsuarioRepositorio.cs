using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Repositorios.Interfaces;

namespace Tarefas.Models {
    public class UsuarioRepositorio : IusuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) {
            _dbContext = sistemaTarefasDBContext; 
        }
         public async Task<UsuarioModel> BuscarPorId(int Id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

         public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);
            if(usuarioPorId == null) {
                throw new Exception($"Usuario para o ID: {Id} não foi encontrado");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;

        }

        public async Task<bool> Apagar(int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);

            if(usuarioPorId == null) {
                throw new Exception($"Usuario para o ID: {Id} não foi encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

       
    }
}