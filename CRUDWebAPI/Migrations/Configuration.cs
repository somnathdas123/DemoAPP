namespace CRUDWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CRUDWebAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUDWebAPI.Models.TasksDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRUDWebAPI.Models.TasksDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Tasks.AddOrUpdate(p => p.TaskId,
               new Task { TaskName = "Task1", Priority = "p1", TaskDate = System.DateTime.Now, EstimatedCost = 12.36, Description = "test" },
               new Task { TaskName = "Task2", Priority = "p1", TaskDate = System.DateTime.Now, EstimatedCost = 12.36, Description = "test" },
               new Task { TaskName = "Task3", Priority = "p1", TaskDate = System.DateTime.Now, EstimatedCost = 12.36, Description = "test" }
               );
        }
    }
}
