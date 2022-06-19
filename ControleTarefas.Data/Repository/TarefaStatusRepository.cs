using ControleTarefas.Business.Intefaces.IRepositories;
using ControleTarefas.Business.Models;
using ControleTarefas.Data.Context;

namespace ControleTarefas.Data.Repository
{
    public class TarefaStatusRepository : Repository<TarefaStatus>, ITarefaStatusRepository
    {
        public TarefaStatusRepository(ApplicationDbContext context) : base(context) { }

    }
}
