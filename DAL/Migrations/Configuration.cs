using BOL;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskContext context)
        {
            foreach (TaskStatusEnum status in Enum.GetValues(typeof(TaskStatusEnum)))
            {
                context.TaskStatuses.AddOrUpdate(new TaskStatus { Id = (int)status, Name = status.ToString("G") });
            }
        }
    }
}
