using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class Event
	{
		public int Id { get; set; }
		//Admin that runs the event.
		public virtual User User { get; set; }
		//List of workers
		public List<User> Volunteers { get; set; }
		public string Description { get; set; }
		public DateTime Time { get; set; }
		public int WantedAmountVolunteers { get; set; }
		// Attendance is for the list of users who will be attending as guest versus workers
		public List<User> Attendance { get; set; }

		public Event() { }
	}
}