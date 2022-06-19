using ControleTarefas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Business.Intefaces.IRepositories
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<IEnumerable<Tarefa>> ObterTodasTarefas();
        Task<Tarefa> ObterTarefa_StatusEPrioridade(int codTarefa);

    }
}
