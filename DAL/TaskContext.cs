using BOL;
using System.Data.Entity;

namespace DAL
{
    class TaskContext : DbContext
    {
        public TaskContext() : base(DBConnection.GetConnectionString())
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
