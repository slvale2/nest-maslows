using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VolunteerProject.Models;
using VolunteerProject.Utility;

namespace VolunteerProject.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class UsersController : ApiController
    {
		private VolunteerContext db = new VolunteerContext();

		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id) {
			if (id == null)
				return new JsonResponse { Message = "Null Value", Error = "Null", Result = "failed" };
			User u = db.Users.Find(id);
			return new JsonResponse { Data = u };
		}
		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			List<User> users = db.Users.ToList();
			return new JsonResponse { Data = users };
		}

		[HttpPost]
		[ActionName("Add")]
		public JsonResponse Add(User user) {
			if (user == null)
				return new JsonResponse { Error = "null", Message = "Null user", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "non valid user", Result = "failed" };
			db.Users.Add(user);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(User user) {
			if (user == null)
				return new JsonResponse { Error = "null", Message = "Null user", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "non valid user", Result = "failed" };
			User u = db.Users.Find(user.Id);
			u.Email = user.Email;
			u.Firstname = user.Firstname;
			u.Lastname = user.Lastname;
			u.Password = user.Password;
			u.Username = user.Username;
			u.IsAdmin = user.IsAdmin;
			u.IsVolunteer = user.IsVolunteer;
			u.Hours = user.Hours;
			u.Phone = user.Phone;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Delete")]
		public JsonResponse Delete(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = "null", Message = "Id is null", Result = "failed" };
			User u = db.Users.Find(id);
			db.Users.Remove(u);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("Promote")]
		public JsonResponse PromoteToAdmin(User user, int? id) {
			if (user == null)
				return new JsonResponse { Error = "null", Message = "Null user", Result = "Failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = "not valid", Message = "non valid user", Result = "failed" };
			if (id == null)
				return new JsonResponse { Error = "null", Message = "Null id", Result = "failed" };
			if (user.IsAdmin == false)
				return new JsonResponse { Error = "not high clearance", Message = "User does not have the authority", Result = "failed" };
			User u = db.Users.Find(id);
			u.IsAdmin = true;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpGet]
		[ActionName("login")]
		public JsonResponse login(string username, string password)
		{
			if (username == null || password == null)
				return new JsonResponse { Error = -3, Message = "the password or user name is null", Result = "failed" };
			var user = db.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
			if (user == null)
				return new JsonResponse { Error = -7, Message = "there is no account", Result = "failed" };
			return new JsonResponse { Data = user };
		}
    }
}
