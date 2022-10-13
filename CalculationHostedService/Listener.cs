using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;
using Azure.Storage.Queues;

namespace CalculationHostedService
{
    public class Listener : BackgroundService
    {
        private IConnection _connection;
        private IProducer _producer;
        private IModel _channel;
        private string? _queueName;
        private readonly ILogger _logger;
        public Listener(IProducer producer, ILogger<Listener> logger)
        {
            _producer = producer;
            //var factory = new ConnectionFactory { HostName = "rabbitmq" };
            //_connection = factory.CreateConnection();
            //_channel = _connection.CreateModel();
            //_channel.ExchangeDeclare(exchange: "TestExchange", type: ExchangeType.Direct);
            //_queueName = _channel.QueueDeclare().QueueName;
            //_channel.QueueBind(queue: _queueName, exchange: "TestExchange", routingKey: "send");
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=ytvideo;AccountKey=MJQIvUu3y0zPXEntuYI6uYlBqxaQlyEefPSYaMU/Ee+A/I7cU+AfpCHcEXZeMUkhwVhPw+RFHjwc+AStl6y8WQ==;EndpointSuffix=core.windows.net";
            var gueueName = "hostedlistener";
            var queueClient = new QueueClient(connectionString, gueueName);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Reading from the queue");
                var queueMessage = await queueClient.ReceiveMessageAsync();

                if (queueMessage.Value != null)
                {
                    var data = JsonConvert.DeserializeObject<List<int>>(queueMessage.Value.MessageText);
                    _logger.LogInformation($"New Message Read: {data}");

                    await _producer.SendMessageAzure(data);
                    await queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }
            }
            await Task.Delay(TimeSpan.FromSeconds(1));


            // For RabbitMQ
            //stoppingToken.ThrowIfCancellationRequested();

            //var consumer = new EventingBasicConsumer(_channel);
            //consumer.Received += async (ch, ea) =>
            //{
            //    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            //    var sequence = JsonConvert.DeserializeObject<List<int>>(content);
            //    Console.WriteLine($"HostedService: Received message from AlgorithmAPI {content}"); 

            //   await _producer.SendMessage(sequence);
            //};
            //_channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

           // return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}