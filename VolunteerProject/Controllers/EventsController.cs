using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VolunteerProject.Utility;
using VolunteerProject.Models;
using System.Web.Http.Cors;

namespace VolunteerProject.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class EventsController : ApiController
    {
		private VolunteerContext db = new VolunteerContext();

		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = "null", Message = "Id is a null value", Result = "failed" };
			Event @event = db.Events.Find(id);
			return new JsonResponse { Data = @event };
		}

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			List<Event> events = db.Events.ToList();
			return new JsonResponse { Data = events };
		}

		[HttpPost]
		[ActionName("Add")]
		public JsonResponse Add(User user, Event @event) {
			if (@event == null || user == null)
				return new JsonResponse { Error = "null", Message = "Data has null values", Result = "Failed" };
			if (user.IsAdmin == false)
				return new JsonResponse { Error = "not admin", Message = "User cannot create event", Result = "failed" };
			db.Events.Add(@event);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Event @event) {
			if (@event == null)
				return new JsonResponse { Error = "null", Message = "Null user", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "non valid user", Result = "failed" };
			Event e = db.Events.Find(@event.Id);
			e.Time = @event.Time;
			e.User = @event.User;
			e.Volunteers = @event.Volunteers;
			e.WantedAmountVolunteers = @event.WantedAmountVolunteers;
			e.Attendance = @event.Attendance;
			e.Description = @event.Description;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Delete")]
		public JsonResponse Delete(int? id) {
			if (id == null)
				return new JsonResponse { Error = "null", Message = "Null id", Result ="failed"};
			Event e = db.Events.Find(id);
			db.Events.Remove(e);
			db.SaveChanges();
			return new JsonResponse();
		}
		[HttpPost]
		[ActionName("AddVolunteer")]
		public JsonResponse AddVolunteer(User user, Event @event) {
			if (user == null || @event==null)
				return new JsonResponse { Error = "null", Message = "Null user", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "non valid user", Result = "failed" };
			if (user.IsVolunteer == false || user.IsAdmin == false)
				return new JsonResponse { Error = "is not a volunteer", Message = "not accessible to public users", Result = "failed" };
			Event e = db.Events.Find(@event);
			var users = e.Volunteers;
			users.Add(user);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("AddAttenace")]
		public JsonResponse AddAttendance(User user, Event @event)
		{
			if (user == null || @event == null)
				return new JsonResponse { Error = "null", Message = "Null user", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "non valid user", Result = "failed" };
			Event e = db.Events.Find(@event);
			var attendance = e.Attendance;
			attendance.Add(user);
			db.SaveChanges();
			return new JsonResponse();
		}


    }
}
