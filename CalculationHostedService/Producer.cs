using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CalculationHostedService
{
    public interface IProducer
    {
        void SendMessage(List<int> unsortedList);
    }

    public class Producer : IProducer
    {
       // private ICalculation _calculation;
        //public Producer(ICalculation calculation)
        //{
        //    _calculation = calculation;

        //}
        public void SendMessage(List<int> unsortedList)
        {
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
