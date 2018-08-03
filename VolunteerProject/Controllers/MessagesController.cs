using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VolunteerProject.Utility;
using VolunteerProject.Models;

namespace VolunteerProject.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]

	public class MessagesController : ApiController
    {
		private VolunteerContext db = new VolunteerContext();

		[HttpGet]
		[ActionName("get")]
		public JsonResponse get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = -2, Message = "the id is null", Result = "false" };
			var m = db.Messages.Find(id);
			return new JsonResponse { Data = m };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			var ms = db.Messages.ToList();
			return new JsonResponse { Data = ms };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(Message message) {
			if (message == null)
				return new JsonResponse { Error = -2, Message = "the message is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the message is not valid", Result = "failed" };
			db.Messages.Add(message);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("edit")]
		public JsonResponse edit(Message message)
		{
			if (message == null)
				return new JsonResponse { Error = -2, Message = "the message is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the message is not valid", Result = "failed" };
			var m = db.Messages.Find(message.Id);
			m.message = message.message;
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(Message message)
		{
			if (message == null)
				return new JsonResponse { Error = -2, Message = "the message is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the message is not valid", Result = "failed" };

			var m = db.Messages.Find(message.Id);
			db.Messages.Remove(m);
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
