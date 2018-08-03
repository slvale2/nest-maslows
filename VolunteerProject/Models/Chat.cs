using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class Chat
	{
		public int Id { get; set; }

		public List<int> UserIds { get; set; }
		public virtual List<User> Users { get; set; }

		public List<int> MessageIds { get; set; }
		public virtual List<Message> Messages { get; set; }

		public Chat() { }

	}
}