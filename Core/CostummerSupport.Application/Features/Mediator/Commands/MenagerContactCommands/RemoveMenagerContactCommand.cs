using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Commands.MenagerContactCommands
{
    public class RemoveMenagerContactCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveMenagerContactCommand(int id)
        {
            Id = id;
        }
    }
}
