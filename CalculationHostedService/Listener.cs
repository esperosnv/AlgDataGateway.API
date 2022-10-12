using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculationHostedService
{
    public class Listener : BackgroundService
    {
        private IConnection _connection;
        private IProducer _producer;
        private IModel _channel;
        private string? _queueName;
        public Listener(IProducer producer)
        {
            _producer = producer;
            var factory = new ConnectionFactory { HostName = "rabbitmq" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "TestExchange", type: ExchangeType.Direct);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "TestExchange", routingKey: "send");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var sequence = JsonConvert.DeserializeObject<List<int>>(content);
                Console.WriteLine($"HostedService: Received message from AlgorithmAPI {content}");

               await _producer.SendMessage(sequence);
            };
            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}