using Aula_RabbitMq.Model;
using Aula_RabbitMq_MassTransit.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula_RabbitMq_MassTransit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBusService _busService;

        public CustomerController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pessoa pessoa)
        {
            var @event = new Pessoa(pessoa.Nome, pessoa.Idade, pessoa.Cidade);

            await _busService.Publish(pessoa);

            return NoContent();
        }
    }
}
