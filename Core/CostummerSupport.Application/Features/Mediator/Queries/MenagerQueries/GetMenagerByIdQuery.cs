using CostummerSupport.Application.Features.Mediator.Results.MenagerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Queries.MenagerQueries
{
    public class GetMenagerByIdQuery:IRequest<GetMenagerByIdQueryResult>

    {
        public int Id { get; set; }

        public GetMenagerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
