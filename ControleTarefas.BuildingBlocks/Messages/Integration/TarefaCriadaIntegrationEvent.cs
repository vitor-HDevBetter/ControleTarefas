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

        public TarefaCriadaIntegrationEvent(int codTarefa)
        {
            CodTarefa = codTarefa;
        }
    }
}
