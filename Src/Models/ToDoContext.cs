using Microsoft.EntityFrameworkCore;

namespace WebCoreTest.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }
        public DbSet<TodoItem>? ToDo { get; set; }
        public DbSet<WebInfo>? Info { get; set; }
        public DbSet<VersionInfo> VersionInfo { get; set; }

        //The below is used to seeding the DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (var i = 0; i < 9; i++)
            {
                modelBuilder.Entity<TodoItem>().HasData(
                    new TodoItem
                    {
                        Id = i + 1,
                        IsDone = i % 3 == 0,
                        Name = "Task " + (i + 1),
                        Priority = i % 5 + 1
                    });
            }

            modelBuilder.Entity<WebInfo>().HasData(
                    new WebInfo
                    {
                        Id = 1,
                        Version = "0.03",
                        CopyrightYear = 1638,
                        Approved = true,
                        TagsToShow = 131
                    }) ;
        }
    }
}
