using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Commands.UserCommands;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.UserHandlers
{
	public class RemoveUserCommandHandler:IRequestHandler<RemoveUserCommand>

	{
		private readonly IRepository<AppUser> _repository;

		public RemoveUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}


		public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);

			await _repository.RemoveAsync(values);
		}
	}
}
