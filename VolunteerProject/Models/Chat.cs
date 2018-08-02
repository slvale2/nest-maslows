using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class Chat
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public int UserBId { get; set; }
		public virtual User UserB { get; set; }

		public virtual List<Message> Messages { get; set; }

		public Chat() { }

	}
}