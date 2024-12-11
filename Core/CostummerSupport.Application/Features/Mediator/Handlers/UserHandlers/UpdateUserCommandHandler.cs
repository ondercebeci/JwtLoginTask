using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Commands.UserCommands;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CostummerSupport.Application.Features.Mediator.Handlers.UserHandlers
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateMenagerCommand>
	{
		private readonly IRepository<AppUser> _repository;

		public UpdateUserCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}


		public async Task Handle(UpdateMenagerCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.AppUserId);
			values.Name = request.Name;
			values.Surname = request.Surname;
			values.Email = request.Email;
			values.Password = request.Password;
			values.Username = request.Username;
			values.AppRoleId = request.AppRoleId;
			await _repository.UpdateAsync(values);

		}
	}
}
