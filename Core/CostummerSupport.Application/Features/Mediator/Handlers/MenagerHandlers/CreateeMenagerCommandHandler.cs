using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Enums;
using CostummerSupport.Application.Features.Mediator.Commands.MenagerCommands;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.MenagerHandlers
{
    public class CreateeMenagerCommandHandler : IRequestHandler<CreateeMenagerCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateeMenagerCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateeMenagerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser

            {
                Password = request.Password,
                Username = request.Username,
                AppRoleId = (int)RolesType.Menager,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            });
        }
    }
}
