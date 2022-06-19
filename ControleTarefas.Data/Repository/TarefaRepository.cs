using ControleTarefas.Business.Intefaces.IRepositories;
using ControleTarefas.Business.Models;
using ControleTarefas.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Tarefa>> ObterTodasTarefas()
        {
            return await Db.Tarefa.AsNoTracking()
                .Include(f => f.TarefaStatus)
                .Include(f => f.TarefaPrioridade)
                .OrderByDescending(p => p.DataInsercao).ToListAsync();
        }

        public async Task<Tarefa> ObterTarefa_StatusEPrioridade(int codTarefa)
        {
            return await Db.Tarefa.AsNoTracking().Where(x => x.CodTarefa == codTarefa)
                .Include(f => f.TarefaStatus)
                .Include(f => f.TarefaPrioridade)
                .OrderByDescending(p => p.DataInsercao).FirstOrDefaultAsync();
        }


    }
}
