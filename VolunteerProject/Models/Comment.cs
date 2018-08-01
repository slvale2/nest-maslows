using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }

		public string Content { get; set; }
		public virtual Forum Forum { get; set; }
		public int ForumId { get; set; }

		public Comment() { }
	}
}