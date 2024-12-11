﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumerSupport.Dto.ContactDto
{
	public class CreateContactDto
	{
		
		public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public DateTime SendDate { get; set; }
		public string? Status { get; set; }
	}
}
