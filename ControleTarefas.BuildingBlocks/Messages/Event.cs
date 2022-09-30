using System;

namespace ControleTarefas.BuildingBlocks.Messages
{
    public class Event : Message
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}