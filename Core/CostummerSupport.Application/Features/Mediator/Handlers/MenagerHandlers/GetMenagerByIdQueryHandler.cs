using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Queries.MenagerQueries;
using CostummerSupport.Application.Features.Mediator.Results.MenagerResults;
using CostummerSupport.Application.Features.Mediator.Results.UserResults;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.MenagerHandlers
{
    public class GetMenagerByIdQueryHandler : IRequestHandler<GetMenagerByIdQuery, GetMenagerByIdQueryResult>
    {
        private readonly IRepository<AppUser> _repository;

        public GetMenagerByIdQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<GetMenagerByIdQueryResult> Handle(GetMenagerByIdQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetByIdAsync(request.Id);
            return new GetMenagerByIdQueryResult
            {
                Name = values.Name,
                AppUserId = values.AppUserId,
                AppRoleId = values.AppRoleId,
                Email = values.Email,
                Password = values.Password,
                Surname = values.Surname,
                Username = values.Username
            };
        }
    }
}
