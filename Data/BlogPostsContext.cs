using Microsoft.EntityFrameworkCore;
using BlogPosts.Models;

namespace BlogPosts.Data
{
    public class BlogPostsContext : DbContext
    {
        public BlogPostsContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>().HasData(
                new Blog { BlogId = 1, Url = "www.sample.com" }
            );

            builder.Entity<Post>().HasData(
                new Post { BlogId = 1, PostId = 1, Title = "First post", Content = "Test 1" },
                new Post { BlogId = 1, PostId = 2, Title = "Second post", Content = "Test 2" }
            );
        }
    }
}
