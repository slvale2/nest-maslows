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
	public class ForumsController : ApiController
    {
		private VolunteerContext db = new VolunteerContext();
		[HttpGet]
		[ActionName("get")]
		public JsonResponse get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = -2, Message = "id is null", Result = "failed" };
			var f = db.Forums.Find(id);
			return new JsonResponse { Data = f };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			var fs = db.Forums.ToList();
			return new JsonResponse { Data = fs };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(Forum forum)
		{
			if (forum == null)
				return new JsonResponse { Error = -2, Message = "the forum is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the forum is valid", Result = "failed" };
			db.Forums.Add(forum);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("change")]
		public JsonResponse change(Forum forum)
		{
			if (forum == null)
				return new JsonResponse { Error = -2, Message = "the forum is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the forum is valid", Result = "failed" };
			var f = db.Forums.Find(forum.Id);
			f.Content = forum.Content;
			f.Title = forum.Title;
			db.SaveChanges();
			return new JsonResponse();
		}
		
		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(Forum forum)
		{
			if (forum == null)
				return new JsonResponse { Error = -2, Message = "the forum is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the forum is valid", Result = "failed" };
			db.Forums.Remove(forum);
			db.SaveChanges();
			return new JsonResponse();

		}
    }
}
