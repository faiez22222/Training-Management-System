using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem
{
    public class BloggingContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingContext():base("name=devDB")
        {
            // Database.SetInitializer(new BloggingInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BloggingContext , BloggingSystem.Migrations.Configuration>());
        }   
    }
    public class BloggingInitializer : DropCreateDatabaseIfModelChanges<BloggingContext>
    {
        protected override void Seed(BloggingContext context)
        {
            context.Blogs.Add(new Blog
            {
                BlogName = "Tech Blog",
                BlogType = "Technology",
                BlogHeader = "Latest Tech News",
                BlogDescription = "All about the latest in technology."
            });

            context.Blogs.Add(new Blog
            {
                BlogName = "Travel Blog",
                BlogType = "Travel",
                BlogHeader = "Adventures Around the World",
                BlogDescription = "Travel stories and tips from around the world."
            });
        }
    }
}
