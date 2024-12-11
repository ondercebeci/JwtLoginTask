using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Queries.MenagerContactQueries;
using CostummerSupport.Application.Features.Mediator.Results.ContactResults;
using CostummerSupport.Application.Features.Mediator.Results.MenagerContactResults;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.MenagerContactHandlers
{
    public class GetMenagerContactByIdQueryHandler : IRequestHandler<GetMenageerContactByIdQuery, GetMenageerContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;

        public GetMenagerContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

      

        public async Task<GetMenageerContactByIdQueryResult> Handle(GetMenageerContactByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetMenageerContactByIdQueryResult
            {
                ContactId=values.ContactId,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Message = values.Message,
                Subject = values.Subject,
                Status = values.Status,
                SendDate = values.SendDate

            };
        }
    }
}
