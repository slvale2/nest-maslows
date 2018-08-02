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
	public class CommentsController : ApiController
    {
		private VolunteerContext db = new VolunteerContext();

		[HttpGet]
		[ActionName("get")]
		public JsonResponse get(int? id)
		{
			if (id == null)
				return new JsonResponse { Error = -2, Message = "id is null", Result = "Failed" };
			var c = db.Comments.Find(id);
			return new JsonResponse { Data = c };
		}

		[HttpGet]
		[ActionName("list")]
		public JsonResponse list()
		{
			var cs = db.Comments.ToList();
			return new JsonResponse { Data = cs };
		}

		[HttpPost]
		[ActionName("create")]
		public JsonResponse create(Comment comment)
		{
			if (comment == null)
				return new JsonResponse { Error = -2, Message = "the comment is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the comment isnt valid", Result = "failed" };
			db.Comments.Add(comment);
			db.SaveChanges();
			return new JsonResponse();
		}

		[HttpPost]
		[ActionName("change")]
		public JsonResponse change(Comment comment)
		{
			if (comment == null)
				return new JsonResponse { Error = -2, Message = "the comment is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the comment isnt valid", Result = "failed" };
			var c = db.Comments.Find(comment.Id);
			c.Content = comment.Content;
			db.SaveChanges();
			return new JsonResponse();
		}
		
		[HttpPost]
		[ActionName("delete")]
		public JsonResponse delete(Comment comment)
		{
			if (comment == null)
				return new JsonResponse { Error = -2, Message = "the comment is null", Result = "failed" };
			if (!ModelState.IsValid)
				return new JsonResponse { Error = -4, Message = "the comment isnt valid", Result = "failed" };
			var c = db.Comments.Find(comment.Id);
			db.Comments.Remove(c);
			db.SaveChanges();
			return new JsonResponse();
		}
    }
}
