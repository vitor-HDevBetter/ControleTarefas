using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.BuildingBlocks.Helpers
{
    public class Enums
    {
        public enum TipoExchange
        {
            [Description("direct")]
            direct,
            [Description("topic")]
            topic,
            [Description("fanout")]
            fanout
        }



    }
}
