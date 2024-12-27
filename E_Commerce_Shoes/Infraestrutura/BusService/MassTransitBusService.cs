
using MassTransit;

namespace Aula_RabbitMq_MassTransit.Service
{
    public class MassTransitBusService : IBusService
    {
        private readonly IBus _bus;
        private readonly string _exchangeName;
        private readonly string _queueName;

        public MassTransitBusService(IBus bus, IConfiguration configuration)
        {
            _bus = bus;
            _exchangeName = configuration["ConnectionStrings:RabbitMQ:ExchangeName"] ?? throw new Exception("ExchangeName não configurado!");
            _queueName = configuration["ConnectionStrings:RabbitMQ:QueueName"] ?? throw new Exception("QueueName não configurado!");
        }

        public async Task Publish<T>(T message)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri($"rabbitmq://localhost/{_exchangeName}"));
            await endpoint.Send(message);
        }
    }
}
