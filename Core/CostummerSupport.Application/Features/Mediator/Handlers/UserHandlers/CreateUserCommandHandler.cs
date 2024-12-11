using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Enums;
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
	public class CreateMenagerCommandHandler : IRequestHandler<CreateMenagerCommand>
	{private readonly IRepository<AppUser> _repository;

		public CreateMenagerCommandHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		
		public async Task Handle(CreateMenagerCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new AppUser
			{
                Password = request.Password,
                Username = request.Username,
                AppRoleId = (int)RolesType.Member,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname

            });
		}
	}
}
