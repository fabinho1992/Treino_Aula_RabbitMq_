using E_Commerce_Shoes.Models;
using MediatR;
namespace E_Commerce_Shoes.Application.Commands.Usuarios
{
    public class CreateUsuarioCommand : IRequest<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
