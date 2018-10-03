using System.Data.Entity;

namespace CRUDWebAPI.Models
{
    public class TasksDBContext : DbContext
    {
        public TasksDBContext() : base("name=TasksDBContext")
        {
            //NO Implementation
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
