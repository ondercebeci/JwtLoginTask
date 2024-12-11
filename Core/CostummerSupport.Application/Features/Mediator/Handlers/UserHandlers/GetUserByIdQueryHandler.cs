using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Queries.UserQueries;
using CostummerSupport.Application.Features.Mediator.Results.UserResults;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IRepository<AppUser> _repository;

        public GetUserByIdQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetUserByIdQueryResult
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
