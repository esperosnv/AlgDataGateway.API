namespace Algorithms.API.RabbitMQ
{
    public interface IRabbitMqService
    {
        Task SendMessage<T>(T message);
        Task SendMessageAzure<T>(T message);
    }
}
