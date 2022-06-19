using ControleTarefas.Business.Intefaces.IServices;
using ControleTarefas.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected string msgErroPadrao = "Ocorreu um erro interno, por favor contate a equipe HDevBetter";
        protected string defaultView = "~/Views/Shared/Components/Summary/Default.cshtml";

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificador.ObterNotificacoes();
        }

        public struct RetornoJson
        {
            public bool success;
            public string msg;
            public object retorno;
        };


    }
}
