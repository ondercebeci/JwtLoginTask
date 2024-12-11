using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Commands.MenagerCommands;
using CostummerSupport.Application.Features.Mediator.Commands.UserCommands;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.MenagerHandlers
{
	public class RemoveMenagerCommandHandler:IRequestHandler<RemoveeMenagerCommand>

	{
		private readonly IRepository<AppUser> _repository;

		public RemoveMenagerCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}


		public async Task Handle(RemoveeMenagerCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);

			await _repository.RemoveAsync(values);
		}
	}
}
