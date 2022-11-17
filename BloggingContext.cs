using Microsoft.EntityFrameworkCore;

namespace postgresql
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=10.0.0.21;Database=blogging;Username=brian;Password=brian1234");
    }
}
