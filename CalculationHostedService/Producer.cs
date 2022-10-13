using Azure.Storage.Queues;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;

namespace CalculationHostedService
{
    public interface IProducer
    {
        Task SendMessage(List<int> unsortedList);
        Task SendMessageAzure(List<int> unsortedList);
    }

    public class Producer : IProducer
    {
        public Task SendMessage(List<int> unsortedList)
        {
            Thread.Sleep(5000);
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "TestExchange", type: ExchangeType.Direct);
                unsortedList.Sort();
                var jsonString = JsonConvert.SerializeObject(unsortedList);

                var json = JsonConvert.SerializeObject(jsonString);
                var body = Encoding.UTF8.GetBytes(json);
                Console.WriteLine($"HostedService: Send message to AlgorithmAPI {json}");

                channel.BasicPublish(exchange: "TestExchange",
                               routingKey: "receive",
                               basicProperties: null,
                               body: body);

            }
            return Task.CompletedTask;
        }

        public async Task SendMessageAzure(List<int> unsortedList)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=ytvideo;AccountKey=MJQIvUu3y0zPXEntuYI6uYlBqxaQlyEefPSYaMU/Ee+A/I7cU+AfpCHcEXZeMUkhwVhPw+RFHjwc+AStl6y8WQ==;EndpointSuffix=core.windows.net";
            var gueueName = "hostedsender";
            var queueClient = new QueueClient(connectionString, gueueName);
            unsortedList.Sort();
            var json = JsonConvert.SerializeObject(unsortedList);
            await queueClient.SendMessageAsync(json);
        }
    }
}
