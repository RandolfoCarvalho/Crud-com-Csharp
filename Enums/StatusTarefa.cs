using System.ComponentModel;

namespace Tarefas.Enums {
    public enum StatusTarefa 
    {
        [Description("A fazer")]
        AFazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Em andamento")]
        Concluido = 3

    }
}