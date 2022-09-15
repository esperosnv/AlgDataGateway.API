using Algorithms.API.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Algorithms.API.Services;
using DataModels;

namespace Algorithms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
		private readonly IRabbitMqService _mqService;

		public RabbitMqController(IRabbitMqService mqService)
		{
			_mqService = mqService;
		}

		[Route("[action]/{message}")]
		[HttpGet]
		public IActionResult SendMessage(DataSetResponse message)
		{
			_mqService.SendMessage<DataSetResponse>(message);

			return Ok("Сообщение отправлено");
		}
	}
}
