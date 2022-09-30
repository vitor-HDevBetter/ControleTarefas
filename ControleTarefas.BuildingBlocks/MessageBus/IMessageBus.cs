using System;
using System.Threading.Tasks;
using ControleTarefas.BuildingBlocks.Messages.Integration;
using EasyNetQ;

namespace ControleTarefas.BuildingBlocks.MessageBus
{
    public interface IMessageBus : IDisposable
    {
        bool IsConnected { get; }

        void DeclararFila(string queue);
        void DeclararExchange(string exchange, string type);
        void VincularFila(string queue, string exchange, string routingKey);
        void PublicarFila(string exchange, string routingKey, byte[] body);
        void PublicarFila_Direct<T>(string queue, T message) where T : IntegrationEvent;
        dynamic CosumirFila(string queue);


    }
}