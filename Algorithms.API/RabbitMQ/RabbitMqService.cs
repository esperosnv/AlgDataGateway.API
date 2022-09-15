using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;


namespace Algorithms.API.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
	{
		//public void SendMessage(object obj)
		//{
		//	var message = JsonSerializer.Serialize(obj);
		//	SendMessage(message);
		//}

		public void SendMessage<T>(T message)
		{
			// Не забудьте вынести значения "localhost" и "MyQueue"
			// в файл конфигурации
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "MyQueue",
							   durable: false,
							   exclusive: false,
							   autoDelete: false,
							   arguments: null);
				var json = JsonConvert.SerializeObject(message);
				var body = Encoding.UTF8.GetBytes(json);

				channel.BasicPublish(exchange: "",
							   routingKey: "MyQueue",
							   basicProperties: null,
							   body: body);
			}
		}
	}
}
