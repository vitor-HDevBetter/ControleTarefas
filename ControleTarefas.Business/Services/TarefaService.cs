using ControleTarefas.Business.Intefaces.IRepositories;
using ControleTarefas.Business.Intefaces.IServices;
using ControleTarefas.Business.Models;
using ControleTarefas.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository,
                             INotificador notificador) : base(notificador)

        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            await _tarefaRepository.Insert(tarefa);
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            await _tarefaRepository.Update(tarefa);
        }

        public async Task Deletar(Tarefa tarefa)
        {
            await _tarefaRepository.Delete(tarefa);
        }

        public async Task MudarStatus(Tarefa tarefa, TarefaStatus tarefaStatus)
        {
            tarefa.TarefaStatus = tarefaStatus;

            await _tarefaRepository.Update(tarefa);
        }

        public void Dispose()
        {
            _tarefaRepository?.Dispose();
        }
    }
}
