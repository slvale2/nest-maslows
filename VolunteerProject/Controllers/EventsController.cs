using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VolunteerProject.Utility;
using VolunteerProject.Models;

namespace VolunteerProject.Controllers
{
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

    }
}
