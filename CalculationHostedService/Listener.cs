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
        //private IProducer _producer;
        private IModel _channel;
        private string? _queueName;
        public Listener()
        {
            //_producer = producer;
            var factory = new ConnectionFactory { HostName = "localhost" };
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
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var sequence = JsonConvert.DeserializeObject<List<int>>(content);
                Debug.WriteLine($"send message: {content}");

                SendMessage(sequence);
            };

            _channel.BasicConsume(queue: _queueName,
                                     autoAck: true,
                                     consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

        public void SendMessage(List<int> unsortedList)
        {
            Thread.Sleep(10000);
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "TestExchange", type: ExchangeType.Direct);
                List<int> sortedValue = bubbleSort(unsortedList);
                var jsonString = JsonConvert.SerializeObject(sortedValue);

                var json = JsonConvert.SerializeObject(jsonString);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "TestExchange",
                               routingKey: "receive",
                               basicProperties: null,
                               body: body);
            }
        }

        private List<int> bubbleSort(List<int> listForSorting)
        {
            List<int> elements = listForSorting;
            int elementsCount = listForSorting.Count;

            for (int i = 0; i < elementsCount - 1; i++)
                for (int j = 0; j < elementsCount - i - 1; j++)
                    if (elements[j] > elements[j + 1])
                    {
                        int temp = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = temp;
                    }
            return elements;
        }

    }
}