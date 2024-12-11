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
	public class GetUserByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
	{
		private readonly IRepository<Contact> _repository;

		public GetUserByIdQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetContactByIdQueryResult
			{
                ContactId = values.ContactId,
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
