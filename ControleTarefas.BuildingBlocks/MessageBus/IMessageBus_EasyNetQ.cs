using System;
using System.Threading.Tasks;
using ControleTarefas.BuildingBlocks.Messages.Integration;
using EasyNetQ;

namespace ControleTarefas.BuildingBlocks.MessageBus
{
    public interface IMessageBus_EasyNetQ : IDisposable
    {
        bool IsConnected { get; }
        IAdvancedBus AdvancedBus { get; }

        void Publish<T>(T message) where T : IntegrationEvent;

        Task PublishAsync<T>(T message) where T : IntegrationEvent;

        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class;

        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

        TResponse Request<TRequest, TResponse>(TRequest request);

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request);

    }
}