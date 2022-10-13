using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using Azure.Storage.Queues;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;

namespace Algorithms.API.RabbitMQ
{


    public class RabbitMqListener : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string? _queueName;
        private readonly ILogger _logger;
        private List<int>? _sortedList;

        public RabbitMqListener(ILogger<RabbitMqListener> logger)
        {
            //var factory = new ConnectionFactory { HostName = "rabbitmq" };
            //_connection = factory.CreateConnection();
            //_channel = _connection.CreateModel();
            //_channel.ExchangeDeclare(exchange: "TestExchange", type: ExchangeType.Direct);
            //_queueName = _channel.QueueDeclare().QueueName;
            //_channel.QueueBind(queue: _queueName, exchange: "TestExchange", routingKey: "receive");
            _logger = logger;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var connectionString = "DefaultEndpointsProtocol=https;AccountName=ytvideo;AccountKey=MJQIvUu3y0zPXEntuYI6uYlBqxaQlyEefPSYaMU/Ee+A/I7cU+AfpCHcEXZeMUkhwVhPw+RFHjwc+AStl6y8WQ==;EndpointSuffix=core.windows.net";
            var gueueName = "hostedsender";
            var queueClient = new QueueClient(connectionString, gueueName);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Reading from the queue");
                var queueMessage = await queueClient.ReceiveMessageAsync();

                if (queueMessage.Value != null)
                {
                    var data = JsonConvert.DeserializeObject<List<int>>(queueMessage.Value.MessageText);
                    _logger.LogInformation($"New Message Read: {data}");
                    Console.WriteLine($"AlgorithmAPI: Received message from HostedService: {data}");
                   // _sortedList = data;
                    await queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }
            }
            await Task.Delay(TimeSpan.FromSeconds(1));

            // For RabbitMQ

            //stoppingToken.ThrowIfCancellationRequested();

            //var consumer = new EventingBasicConsumer(_channel);
            //consumer.Received += (ch, ea) =>
            //{
            //	var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            //	Console.WriteLine($"AlgorithmAPI: Received message from HostedService: {content}");
            //	_channel.BasicAck(ea.DeliveryTag, false);

            //};

            //_channel.BasicConsume(_queueName, false, consumer);
            //return Task.CompletedTask;
        }

        //public override void Dispose()
        ////{
        ////    _channel.Close();
        ////    _connection.Close();
        ////    base.Dispose();
        //}

    }
}
