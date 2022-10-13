using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using Azure.Storage.Queues;

namespace Algorithms.API.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
	{ 

		public Task SendMessage<T>(T message)
		{
			var factory = new ConnectionFactory() { HostName = "rabbitmq" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.ExchangeDeclare(exchange: "TestExchange", type: ExchangeType.Direct);
				
				var json = JsonConvert.SerializeObject(message);
				var body = Encoding.UTF8.GetBytes(json);
				channel.BasicPublish(exchange: "TestExchange",
							   routingKey: "send",
							   basicProperties: null,
							   body: body);
				Console.WriteLine($"AlgorithmAPI: Send message to HostedService: {json}");
			}
			return Task.CompletedTask;
		}


		public async Task SendMessageAzure<T>(T message)
		{
			var connectionString = "DefaultEndpointsProtocol=https;AccountName=ytvideo;AccountKey=MJQIvUu3y0zPXEntuYI6uYlBqxaQlyEefPSYaMU/Ee+A/I7cU+AfpCHcEXZeMUkhwVhPw+RFHjwc+AStl6y8WQ==;EndpointSuffix=core.windows.net";
			var gueueName = "hostedlistener";
            var queueClient = new QueueClient(connectionString, gueueName);
            var json = JsonConvert.SerializeObject(message);
            await queueClient.SendMessageAsync(json);
        }
    }
}
