using CostumerSupport.Domain.Entities;
using CostummerSupport.Application.Features.Mediator.Queries.ContactQueries;
using CostummerSupport.Application.Features.Mediator.Results.ContactResults;
using CostummerSupport.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Handlers.ContactHandlers
{
	public class GetUserQueryHandler : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
	{
		private readonly IRepository<Contact> _repository;

		public GetUserQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetContactQueryResult
			{
				ContactId = x.ContactId,
				Name = x.Name,
				Surname = x.Surname,
				Email = x.Email,
				Message = x.Message,
				SendDate = x.SendDate,
				Status = x.Status,
				Subject=x.Subject

			}).ToList();

		}
	}
}
