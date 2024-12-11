using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Commands.MenagerContactCommands;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.MenagerContactHandlers
{
    public class UpdateMenageerContactCommandHandler : IRequestHandler<UpdateeMenagerContactCommand>
    {
        private readonly IRepository<Contact> _repository;

		public UpdateMenageerContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateeMenagerContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ContactId);
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Email = request.Email;
            values.SendDate = request.SendDate;
            values.Subject = request.Subject;
            values.Message = request.Message;
            values.Status = request.Status;
            await _repository.UpdateAsync(values);
        }
    }
}

//public class UpdateUserCommandHandler : IRequestHandler<UpdateMenagerCommand>
//{
//    private readonly IRepository<AppUser> _repository;

//    public UpdateUserCommandHandler(IRepository<AppUser> repository)
//    {
//        _repository = repository;
//    }


//    public async Task Handle(UpdateMenagerCommand request, CancellationToken cancellationToken)
//    {
//        var values = await _repository.GetByIdAsync(request.AppUserId);
//        values.Name = request.Name;
//        values.Surname = request.Surname;
//        values.Email = request.Email;
//        values.Password = request.Password;
//        values.Username = request.Username;
//        values.AppRoleId = request.AppRoleId;
//        await _repository.UpdateAsync(values);

//    }