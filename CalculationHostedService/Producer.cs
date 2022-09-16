using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;

namespace CalculationHostedService
{
    public interface IProducer
    {
        void SendMessage(List<int> unsortedList);
    }

    public class Producer : IProducer
    {
        public void SendMessage(List<int> unsortedList)
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
        }
    }
}
