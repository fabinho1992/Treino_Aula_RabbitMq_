using E_Commerce_Shoes.Models;
using E_Commerce_Shoes.Services;
using MassTransit;
using MediatR;

namespace E_Commerce_Shoes.Application.Commands.Usuarios
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Usuario>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IBus _bus;

        public CreateUsuarioCommandHandler(IUsuarioRepository repository, IBus bus)
        {
            _repository = repository;
            _bus = bus;
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
            await _bus.Publish(usuario);

            return usuario;
        }
    }
}
