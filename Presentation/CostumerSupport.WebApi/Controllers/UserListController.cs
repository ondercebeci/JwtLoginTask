using CostummerSupport.Application.Features.Mediator.Commands.UserCommands;
using CostummerSupport.Application.Features.Mediator.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostumerSupport.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserListController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        
        public async Task<IActionResult> UserList()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateMenagerCommand command)
        {
            await _mediator.Send(command);
            return Ok("User  Başatıyla eklendi");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok("User  Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var value = await _mediator.Send(new GetUserByIdQuery(id));

            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateMenagerCommand command)
        {
            await _mediator.Send(command);
            return Ok("User  Başarıyla Güncellendi");
        }
    }
}
