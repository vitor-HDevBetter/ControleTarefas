using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ControleTarefas.ViewModels;
using ControleTarefas.Business.Intefaces.IServices;
using ControleTarefas.Business.Models;
using ControleTarefas.Models;
using ControleTarefas.Extensions;
using ControleTarefas.Business.Intefaces.IRepositories;
using static ControleTarefas.Data.Helpers.Enums;

namespace ControleTarefas.Controllers
{
    public class TarefaController : BaseController
    {
        private readonly ITarefaService _tarefaService;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaPrioridadeRepository _tarefaPrioridadeRepository;
        private readonly ITarefaStatusRepository _tarefaStatusRepository;
        private readonly IMapper _mapper;

        public TarefaController(
            IMapper mapper,
            INotificador notificador,
            ITarefaRepository tarefaRepository,
            ITarefaService tarefaService,
            ITarefaPrioridadeRepository tarefaPrioridadeRepository,
            ITarefaStatusRepository tarefaStatusRepository) : base(notificador)
        {
            _mapper = mapper;
            _tarefaService = tarefaService;
            _tarefaPrioridadeRepository = tarefaPrioridadeRepository;
            _tarefaRepository = tarefaRepository;
            _tarefaStatusRepository = tarefaStatusRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TarefaViewModel> listaTarefas = _mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterTodasTarefas());

            TarefaViewModel tarefaViewModel = await PopularTarefaPrioridade(new TarefaViewModel());

            tarefaViewModel.TarefasBacklog = listaTarefas.Where(x => x.TarefaStatus.CodTarefaStatus == (int)TarefaStatusEnum.Backlog);
            tarefaViewModel.TarefasToDo = listaTarefas.Where(x => x.TarefaStatus.CodTarefaStatus == (int)TarefaStatusEnum.Todo);
            tarefaViewModel.TarefasInProgress = listaTarefas.Where(x => x.TarefaStatus.CodTarefaStatus == (int)TarefaStatusEnum.InProgress);
            tarefaViewModel.TarefasDone = listaTarefas.Where(x => x.TarefaStatus.CodTarefaStatus == (int)TarefaStatusEnum.Done);

            return View(tarefaViewModel);
        }

        public async Task<IActionResult> OpenModalCriarEditarTarefa(int? codTarefa)
        {
            try
            {
                TarefaViewModel tarefaViewModel = new TarefaViewModel();

                if (codTarefa != null)
                    tarefaViewModel = _mapper.Map<TarefaViewModel>(await _tarefaRepository.GetById((int)codTarefa));

                tarefaViewModel = await PopularTarefaPrioridade(tarefaViewModel);

                return View("~/Views/Tarefa/_CriarEditarTarefa.cshtml", tarefaViewModel);
            }
            catch (Exception ex)
            {
                return View(defaultView, new DefautlViewModel() { msg = msgErroPadrao });
            }
        }

        public async Task<IActionResult> CriarEditarTarefa(TarefaViewModel tarefaViewModel)
        {
            var res = new RetornoJson() { success = false };

            try
            {
                if (!ModelState.IsValid) return View(defaultView, new DefautlViewModel() { msg = HelpersExtensions.ObterErrosModelState(ModelState) });

                if (tarefaViewModel.CodTarefa != null)
                    await _tarefaService.Atualizar(_mapper.Map<Tarefa>(tarefaViewModel));
                else
                    await _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefaViewModel));

                if (!OperacaoValida()) return View(defaultView, new DefautlViewModel() { msg = HelpersExtensions.ObterErrosNotificacoes(ObterNotificacoes()) });

                res.success = true;

                return Json(res);
            }
            catch (Exception ex)
            {
                return View(defaultView, new DefautlViewModel() { msg = msgErroPadrao });
            }
        }

        public async Task<IActionResult> ObterDescricao(int codTarefa)
        {
            try
            {
                TarefaViewModel tarefaViewModel = _mapper.Map<TarefaViewModel>(await _tarefaRepository.ObterTarefa_StatusEPrioridade(codTarefa));

                return View("~/Views/Tarefa/_Descricao.cshtml", tarefaViewModel);
            }
            catch (Exception ex)
            {
                return View(defaultView, new DefautlViewModel() { msg = msgErroPadrao });
            }
        }

        public async Task<IActionResult> MudarStatus(int codTarefa, string status)
        {
            var res = new RetornoJson() { success = false };

            try
            {
                TarefaStatus tarefaStatus = _tarefaStatusRepository.Get(x => x.Descricao == status).Result.FirstOrDefault();

                if (tarefaStatus == null) throw new Exception();

                Tarefa tarefa = await _tarefaRepository.GetById(codTarefa);

                if (tarefa == null) throw new Exception();

                await _tarefaService.MudarStatus(tarefa, tarefaStatus);

                res.success = true;

                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(new { msg = msgErroPadrao });
            }
        }

        public async Task<IActionResult> Deletar(int codTarefa)
        {
            var res = new RetornoJson() { success = false };

            try
            {
                var tarefa = await _tarefaRepository.GetById(codTarefa);

                if (tarefa == null) throw new Exception();

                await _tarefaService.Deletar(tarefa);

                res.success = true;

                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(new { msg = msgErroPadrao });
            }
        }

        private async Task<TarefaViewModel> PopularTarefaPrioridade(TarefaViewModel tarefaViewModel)
        {
            tarefaViewModel.TarefaPrioridades = _mapper.Map<IEnumerable<TarefaPrioridadeViewModel>>(await _tarefaPrioridadeRepository.GetAll());
            return tarefaViewModel;
        }

    }
}
