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
	public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
	{private readonly IRepository<Contact> _repository;

		public CreateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		
		public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Contact
			{
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Email,
				Message = request.Message,
				Subject = request.Subject,
				Status = "Okunmadı",
				SendDate= request.SendDate

			});
		}
	}
}
