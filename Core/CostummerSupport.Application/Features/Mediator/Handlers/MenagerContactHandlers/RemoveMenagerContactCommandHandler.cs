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
    public class RemoveMenagerContactCommandHandler : IRequestHandler<RemoveMenagerContactCommand>
    {
        private readonly IRepository <Contact> _repository;

        public RemoveMenagerContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveMenagerContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(values);
        }
    }
}
