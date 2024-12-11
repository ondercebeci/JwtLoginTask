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
    public class GetMenagerContactQueryHandler : IRequestHandler<GetMenagerContactQuery, List<GetMenagerContactQueryResult>>
    {
        private readonly IRepository<Contact> _repository;

        public GetMenagerContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetMenagerContactQueryResult>> Handle(GetMenagerContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetMenagerContactQueryResult
            {
                ContactId = x.ContactId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Message = x.Message,
                SendDate = x.SendDate,
                Status = x.Status,
                Subject = x.Subject

            }).ToList();
        }
    }
}
