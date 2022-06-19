using ControleTarefas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Business.Intefaces.IServices
{
    public interface ITarefaService : IDisposable
    {
        Task Adicionar(Tarefa tarefa);
        Task Deletar(Tarefa tarefa);
        Task MudarStatus(Tarefa tarefa, TarefaStatus tarefaStatus);
        Task Atualizar(Tarefa tarefa);


    }
}
