using ControleTarefas.Business.Intefaces.IRepositories;
using ControleTarefas.Business.Models;
using ControleTarefas.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Data.Repository
{
    public class TarefaPrioridadeRepository : Repository<TarefaPrioridade>, ITarefaPrioridadeRepository
    {
        public TarefaPrioridadeRepository(ApplicationDbContext context) : base(context) { }

    }
}
