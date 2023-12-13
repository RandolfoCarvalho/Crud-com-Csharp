using Microsoft.EntityFrameworkCore;
using Tarefas.Controllers;
using Tarefas.Data.Map;
using Tarefas.Models;

using Tarefas.Models;

namespace Tarefas.Data {
    public class SistemaTarefasDBContext : DbContext 
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options)  
        {
            
        }
        //isso aqui é nossa tabela Usuarios e Tarefas
        public DbSet<UsuarioModel> Usuarios {get; set;}
        public DbSet<TarefaModel> Tarefas {get; set;}

        //Este método é chamado pelo Entity Framework Core durante a construção do modelo de banco de dados
        //nesse caso nao estamos especificando nenhuma configuração persdonalizada
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}