using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleTarefas.Business.Models
{
    public class Tarefa
    {
        [Key]
        public int CodTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInsercao { get; set; }
        public int CodTarefaPrioridade { get; set; }
        public int CodTarefaStatus { get; set; }


        [ForeignKey("CodTarefaPrioridade")]
        public TarefaPrioridade TarefaPrioridade { get; set; }

        [ForeignKey("CodTarefaStatus")]
        public TarefaStatus TarefaStatus { get; set; }



    }
}
