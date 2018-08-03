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

	public class ChatsController : ApiController
    {
		private VolunteerContext db = new VolunteerContext();

		[HttpGet]
		[ActionName("get")]
		public JsonResponse get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = -3, Message = "the id is null", Result = "failed" };
			var c = db.Chats.Find(id);
			return new JsonResponse { Data = c };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			var c = db.Chats.ToList();
			return new JsonResponse { Data = c };
		}


		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(Chat chat)
		{
			if (chat == null)
				return new JsonResponse { Error = -2, Message = "the chat is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -7, Message = "the chat is not valid", Result = "failed" };
			db.Chats.Add(chat);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(Chat chat)
		{
			if (chat == null)
				return new JsonResponse { Error = -2, Message = "the chat is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -7, Message = "the chat is not valid", Result = "failed" };
			var c = db.Chats.Find(chat.Id);
			db.Chats.Remove(c);
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
