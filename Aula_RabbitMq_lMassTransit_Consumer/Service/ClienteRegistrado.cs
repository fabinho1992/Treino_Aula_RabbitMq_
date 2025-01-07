using Aula_RabbitMq.Model;
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

            if (@event.Cpf == "1234")
            {
                Console.WriteLine($"Cliente {@event.Nome}, com Cpf - {@event.Cpf}");
            }
            else
            {
                Console.WriteLine("cpf não encontrado");
            }

        }

        public class CpfFilter : IFilter<ConsumeContext<Usuario>>
        {

            public async Task Send(ConsumeContext<Usuario> context, IPipe<ConsumeContext<Usuario>> next)
            {
                if (context.Message.Cpf == "1234")
                {
                    await next.Send(context);
                }
                else
                {

                }
            }


            public void Probe(ProbeContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}

