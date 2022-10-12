using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Diagnostics;
using System;
using Newtonsoft.Json;

namespace Algorithms.API.RabbitMQ
{
	public class RabbitMqListener : BackgroundService
	{
		private IConnection _connection;
		private IModel _channel;
		private string? _queueName;

		public RabbitMqListener()
		{
			var factory = new ConnectionFactory { HostName = "rabbitmq" };
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
			_channel.ExchangeDeclare(exchange: "TestExchange", type: ExchangeType.Direct);
			_queueName = _channel.QueueDeclare().QueueName;
			_channel.QueueBind(queue: _queueName, exchange: "TestExchange", routingKey: "receive");
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();

			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (ch, ea) =>
			{
				var content = Encoding.UTF8.GetString(ea.Body.ToArray());
				Console.WriteLine($"AlgorithmAPI: Received message from HostedService: {content}");
				_channel.BasicAck(ea.DeliveryTag, false);






			};

			_channel.BasicConsume(_queueName, false, consumer);
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
