using Microsoft.EntityFrameworkCore;
using task.Entities;

namespace task.Data
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public TaskDbContext(DbContextOptions options)
            :base(options) {  }
    }
}