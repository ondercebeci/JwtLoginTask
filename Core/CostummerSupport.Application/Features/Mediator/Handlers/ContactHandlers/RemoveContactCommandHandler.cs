using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Commands.ContactCommands;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.ContactHandlers
{
	public class RemoveUserCommandHandler:IRequestHandler<RemoveContactCommand>

	{
		private readonly IRepository<Contact> _repository;

		public RemoveUserCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}


		public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);

			await _repository.RemoveAsync(values);
		}
	}
}
