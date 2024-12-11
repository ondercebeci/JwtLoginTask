using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostummerSupport.Application.Features.Mediator.Commands.MenagerContactCommands
{
	public class UpdateeMenagerContactCommand:IRequest
	{
		public int ContactId { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public DateTime SendDate { get; set; }
		public string? Status { get; set; }
	}
}
