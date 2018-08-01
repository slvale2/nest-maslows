using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class Forum
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public virtual List<Comment> Comments { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public Forum() { }
	}
}