namespace Aula_RabbitMq.Bus
{
    public interface IRabbitMqService
    {
        void Publish<T>(string routingKey, T message);
    }
}
