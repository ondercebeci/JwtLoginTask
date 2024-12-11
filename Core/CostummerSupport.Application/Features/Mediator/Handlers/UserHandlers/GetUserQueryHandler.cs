using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Enums;
using CostummerSupport.Application.Features.Mediator.Queries.UserQueries;
using CostummerSupport.Application.Features.Mediator.Results.UserResults;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.UserHandlers
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
	{
		private readonly IRepository<AppUser> _repository;

		public GetUserQueryHandler(IRepository<AppUser> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();


		return	 values.Select(x => new GetUserQueryResult
			{
				AppUserId = x.AppUserId,
				Name = x.Name,
				Username=x.Username,
				Surname = x.Surname,
				Email = x.Email,
				Password = x.Password,
				AppRoleId = x.AppRoleId


			}).Where(y => y.AppRoleId == 3).ToList();


		}
	}
}
