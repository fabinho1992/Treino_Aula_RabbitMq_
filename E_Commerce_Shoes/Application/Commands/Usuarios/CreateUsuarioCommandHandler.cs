using Aula_RabbitMq_MassTransit.Service;
using E_Commerce_Shoes.Models;
using E_Commerce_Shoes.Services;
using MassTransit;
using MediatR;

namespace E_Commerce_Shoes.Application.Commands.Usuarios
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Usuario>
    {
        private readonly IUsuarioRepository _repository;
        

        public CreateUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
            
        }

        public async Task<Usuario> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                DataNascimento = request.DataNascimento
            };

            await _repository.Create(usuario);
            //await _bus.Publish(usuario);    

            return usuario;
        }
    }
}
