
using E_Commerce_Shoes.Models;
using MassTransit;

namespace Aula_RabbitMq_lMassTransit_Consumer.Service
{
    public class ClienteRegistrado : IConsumer<Usuario> 
    {
        public IServiceProvider ServiceProvider { get; }

        public ClienteRegistrado(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<Usuario> context)
        {
            var @event = context.Message;
            Console.WriteLine($"Cliente {@event.Nome}, com cpf {@event.Cpf} cadastrado");


        }
    }
}
