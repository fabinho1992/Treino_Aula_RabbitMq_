using EasyNetQ;

namespace Aula_RabbitMq.Bus
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IAdvancedBus _bus;
        const string Exchange = "exercicio-RabbitMq";
        const string Queue = "exercicio-created";

        public RabbitMqService(IBus bus)
        {
            _bus = bus.Advanced;
        }

        public void Publish<T>(string routingKey, T message)
        {
            var exchange = _bus.ExchangeDeclare(Exchange, "topic");

            _bus.Publish(exchange, routingKey, true, new Message<T> (message) );
        }
    }
}
