using Aula_RabbitMq.Model;
using MassTransit;

namespace Aula_RabbitMq_lMassTransit_Consumer.Service
{
    public class ClienteRegistrado : IConsumer<Pessoa>
    {
        public IServiceProvider ServiceProvider { get; }

        public ClienteRegistrado(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<Pessoa> context)
        {
            var @event = context.Message;
            Console.WriteLine($"Cliente {@event.Nome}, residente em {@event.Cidade} cadastrado");


        }
    }
}
