using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Commands.MenagerCommands
{
    public class RemoveeMenagerCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveeMenagerCommand(int id)
        {
            Id = id;
        }
    }
}
