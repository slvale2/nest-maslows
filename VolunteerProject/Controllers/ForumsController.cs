using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VolunteerProject.Models;
using VolunteerProject.Utility;

namespace VolunteerProject.Controllers
{
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
		
    }
}
