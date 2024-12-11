using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Commands.ContactCommands;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CostummerSupport.Application.Features.Mediator.Handlers.ContactHandlers
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateContactCommand>
	{
		private readonly IRepository<Contact> _repository;

		public UpdateUserCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}


		public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ContactId);
			values.Name = request.Name;
			values.Surname = request.Surname;
			values.Email = request.Email;
			values.Message = request.Message;
			values.Subject = request.Subject;
			values.Status = request.Status;
			values.SendDate = request.SendDate;
			await _repository.UpdateAsync(values);

		}
	}
}
