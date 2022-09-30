using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.BuildingBlocks.Messages.Integration
{
    public class TarefaCriadaIntegrationEvent : IntegrationEvent
    {
        public int CodTarefa { get; private set; }
        public string Titulo { get; set; }

        public TarefaCriadaIntegrationEvent(int codTarefa, string titulo)
        {
            CodTarefa = codTarefa;
            Titulo = titulo;
        }
    }
}
