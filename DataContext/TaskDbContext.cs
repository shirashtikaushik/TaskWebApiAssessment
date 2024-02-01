using Microsoft.EntityFrameworkCore;

namespace TaskWebApiAssessment.DataContext
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options) { }

        public DbSet<Model.Task> Tasks { get; set; }

    }
}
