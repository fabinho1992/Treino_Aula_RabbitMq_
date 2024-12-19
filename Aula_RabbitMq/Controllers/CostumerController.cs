using Aula_RabbitMq.Bus;
using Aula_RabbitMq.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula_RabbitMq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMqService;
        const string RoutingKey = "exercicio-created";

        public CostumerController(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        [HttpPost]
        public IActionResult Post(Pessoa pessoa)
        {
            var @event = new Pessoa(pessoa.Nome, pessoa.Idade, pessoa.Cidade);
            _rabbitMqService.Publish(RoutingKey, @event);

            return Ok();
        }
    }
}
