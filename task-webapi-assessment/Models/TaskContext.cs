using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace TaskApi.Models
{
    public class TaskContext:DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        public DbSet<Login> Logins { get; set; }    
    }
}
