using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Commands.ContactCommands;
using CostummerSupport.Application.Features.Mediator.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostumerSupport.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ContactController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]

		public async Task<IActionResult> ContactList()
		{
			var values = await _mediator.Send(new GetContactQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetContact(int id)
		{
			var values = await _mediator.Send(new GetContactByIdQuery(id));
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactCommand command)
		{
			await _mediator.Send(command);
			return Ok("Contact Form Başatıyla eklendi");

		}
		[HttpDelete]
		public async Task<IActionResult>RemoveContact(int id)
		{
			await _mediator.Send(new RemoveContactCommand(id));
			return Ok("Contact Form Başarıyla Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
		{
			await _mediator.Send(command);
			return Ok("Contact Form Başarıyla Güncellendi");
		}
		
	}
}
