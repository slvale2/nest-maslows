using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class Message
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public int ChatId { get; set; }
		public virtual Chat Chat { get; set; }
		public string message { get; set; }
		public DateTime date { get; set; }


		public Message() { }
	}
}