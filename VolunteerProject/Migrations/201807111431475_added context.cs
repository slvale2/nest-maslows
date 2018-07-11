namespace VolunteerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Time = c.DateTime(nullable: false),
                        WantedAmountVolunteers = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        IsVolunteer = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Hours = c.Int(nullable: false),
                        Event_Id = c.Int(),
                        Event_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.Events", t => t.Event_Id1)
                .Index(t => t.Event_Id)
                .Index(t => t.Event_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Event_Id1", "dbo.Events");
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_Id", "dbo.Events");
            DropIndex("dbo.Users", new[] { "Event_Id1" });
            DropIndex("dbo.Users", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}
