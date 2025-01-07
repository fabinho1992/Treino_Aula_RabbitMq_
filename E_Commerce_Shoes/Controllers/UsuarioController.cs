using Aula_RabbitMq_MassTransit.Service;
using E_Commerce_Shoes.Application.Commands.Usuarios;
using E_Commerce_Shoes.Dtos;
using E_Commerce_Shoes.Models;
using E_Commerce_Shoes.Services;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Shoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //private IMediator _mediator;

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IBusService _busService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IBusService busService)
        {
            _usuarioRepository = usuarioRepository;
            _busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioRequest usuarioRequest)
        {
            var newUsuario = new Usuario
            {
                Nome = usuarioRequest.Nome,
                Cpf = usuarioRequest.Cpf,  
                DataNascimento = usuarioRequest.DataNascimento
            };

            await _usuarioRepository.Create(newUsuario);
            await _busService.Publish(newUsuario);

            return Ok(newUsuario);
        }
    }
}
