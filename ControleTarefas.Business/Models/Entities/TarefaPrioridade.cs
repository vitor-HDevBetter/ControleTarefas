using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Business.Models
{
    public class TarefaPrioridade
    {
        [Key]
        public int CodTarefaPrioridade { get; set; }
        public string Descricao { get; set; }

    }
}
