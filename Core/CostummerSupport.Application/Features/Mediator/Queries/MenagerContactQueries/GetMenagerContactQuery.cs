using CostummerSupport.Application.Features.Mediator.Results.MenagerContactResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Queries.MenagerContactQueries
{
    public class GetMenagerContactQuery:IRequest<List<GetMenagerContactQueryResult>>
    {
    }
}
