namespace Algorithms.API.RabbitMQ
{
    public interface IRabbitMqService
    {
        void SendMessage<T>(T message);
    }
}
