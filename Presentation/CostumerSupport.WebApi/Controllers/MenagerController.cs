
using CostummerSupport.Application.Features.Mediator.Commands.MenagerCommands;
using CostummerSupport.Application.Features.Mediator.Commands.UserCommands;
using CostummerSupport.Application.Features.Mediator.Queries.MenagerQueries;
using CostummerSupport.Application.Features.Mediator.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostumerSupport.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> MenagerList()
        {
            var values = await _mediator.Send(new GetMenagerQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenager(CreateeMenagerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Menager  Başatıyla eklendi");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMenager(int id)
        {
            await _mediator.Send(new RemoveeMenagerCommand(id));
            return Ok("Menager  Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenager(int id)
        {
            var value = await _mediator.Send(new GetMenagerByIdQuery(id));

            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenager(UpdateeMenagerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Menager  Başarıyla Güncellendi");
        }
    }
}
