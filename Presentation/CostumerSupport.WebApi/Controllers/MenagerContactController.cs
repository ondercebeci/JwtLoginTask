
using CostummerSupport.Application.Features.Mediator.Commands.MenagerContactCommands;
using CostummerSupport.Application.Features.Mediator.Queries.MenagerContactQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostumerSupport.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenagerContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenagerContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]

        public async Task<IActionResult> MenagerContactList()
        {
            var values = await _mediator.Send(new GetMenagerContactQuery());
            return Ok(values);
        }
       
		//[HttpPost]
		//public async Task<IActionResult> CreateContact(CreateMenagerContactCommand command)
		//{
		//    await _mediator.Send(command);
		//    return Ok("Contact Form Başatıyla eklendi");

		//}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveMenagerContact(int id)
        {
            await _mediator.Send(new RemoveMenagerContactCommand(id));
            return Ok("MenagerContact Form Başarıyla Silindi");
        }
		[HttpGet("{id}")]
		public async Task<IActionResult> GetMenagerContact(int id)
		{
			var values = await _mediator.Send(new GetMenageerContactByIdQuery(id));
			return Ok(values);
		}
		[HttpPut]
        public async Task<IActionResult> UpdateMenagerContact(UpdateeMenagerContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("MenagerContact Form Başarıyla Güncellendi");
        }
    }
}
