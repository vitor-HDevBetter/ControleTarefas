using ControleTarefas.BuildingBlocks.Messages.Integration;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;
using System.Text.Json;
using static ControleTarefas.BuildingBlocks.Helpers.Enums;

namespace ControleTarefas.BuildingBlocks.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private IModel _channel;
        private IConnection _connection;
        private EventingBasicConsumer _consumer;
        private dynamic _message;

        private readonly string _connectionString;

        public MessageBus(string connectionString)
        {
            _connectionString = connectionString;
            TryConnect();
        }

        public bool IsConnected => _connection?.IsOpen ?? false;

        public void DeclararFila(string queue)
        {
            TryConnect();
            _channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void DeclararExchange(string exchange, string type)
        {
            TryConnect();
            _channel.ExchangeDeclare(exchange: exchange, type: type);
        }

        public void VincularFila(string queue, string exchange, string routingKey)
        {
            TryConnect();
            _channel.QueueBind(queue: queue, exchange: exchange, routingKey: routingKey);
        }

        public void PublicarFila(string exchange, string routingKey, byte[] body)
        {
            TryConnect();
            _channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: body);
        }

        public void PublicarFila_Direct<T>(string queue, T message) where T : IntegrationEvent
        {
            TryConnect();

            var exchange = queue + "_exchange";
            var routingKey = queue + "_routingKey";
            var message_serialize = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(message_serialize);

            _channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.ExchangeDeclare(exchange: exchange, type: TipoExchange.direct.ToString());
            _channel.QueueBind(queue: queue, exchange: exchange, routingKey: routingKey);
            _channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: body);
        }

        public dynamic CosumirFila(string queue)
        {
            TryConnect();

            _channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var data = _channel.BasicGet(queue, true);
            var message = Encoding.UTF8.GetString(data.Body.ToArray());
            _message = JsonSerializer.Deserialize<TarefaCriadaIntegrationEvent>(message);

            _channel.BasicConsume(queue: queue, autoAck: false, consumer: _consumer);

            return _message ?? null;
        }

        private void TryConnect()
        {
            if (IsConnected) return;

            var policy = Policy.Handle<BrokerUnreachableException>()
                .WaitAndRetry(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                var factory = new ConnectionFactory() { ClientProvidedName = _connectionString };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _consumer = new EventingBasicConsumer(_channel);

                if (!_connection.IsOpen) OnDisconnect();
            });
        }

        private void OnDisconnect()
        {
            var policy = Policy.Handle<BrokerUnreachableException>().RetryForever();

            policy.Execute(TryConnect);
        }

        public void Dispose()
        {
            _channel.Dispose();
        }
    }
}