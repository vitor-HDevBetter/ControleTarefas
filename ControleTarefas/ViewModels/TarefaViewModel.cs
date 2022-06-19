using ControleTarefas.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleTarefas.ViewModels
{
    public class TarefaViewModel
    {
        public int? CodTarefa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Prioridade")]
        public int? CodTarefaPrioridade { get; set; }

        public int? CodTarefaStatus { get; set; }

        public DateTime? DataInsercao { get; set; }

        public TarefasStatusViewModel TarefaStatus { get; set; }

        public TarefaPrioridadeViewModel TarefaPrioridade { get; set; }

        public IEnumerable<TarefaPrioridadeViewModel> TarefaPrioridades { get; set; }

        public IEnumerable<TarefaViewModel> TarefasBacklog { get; set; }

        public IEnumerable<TarefaViewModel> TarefasToDo { get; set; }

        public IEnumerable<TarefaViewModel> TarefasInProgress { get; set; }

        public IEnumerable<TarefaViewModel> TarefasDone { get; set; }


    }
}
