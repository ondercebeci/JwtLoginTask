using CostummerSupport.Application.Features.Mediator.Results.MenagerResults;
using CostummerSupport.Application.Features.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Queries.MenagerQueries
{
    public class GetMenagerQuery : IRequest<List<GetMenagerQueryResult>>
    {
    }
}
