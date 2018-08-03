using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VolunteerProject.Models
{
	public class VolunteerContext : DbContext
	{
		public VolunteerContext() : base() { }

		public DbSet<User> Users { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Forum> Forums { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Message> Messages { get; set; }
	}
}