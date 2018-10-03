namespace CRUDWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskdb_v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    TaskId = c.Int(nullable: false, identity: true),
                    TaskName = c.String(),
                    Priority = c.String(),
                    TaskDate = c.DateTime(nullable: false),
                    EstimatedCost = c.Double(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.TaskId);

        }

        public override void Down()
        {
            DropTable("dbo.Tasks");
        }
    }
}
