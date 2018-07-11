using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool IsVolunteer { get; set; }
		public bool IsAdmin { get; set; }
		public int Hours { get; set; }

		public User() { }
	}
}