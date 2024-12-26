namespace Aula_RabbitMq_MassTransit.Service
{
    public interface IBusService
    {
        Task Publish<T>(T message);
    }
}
