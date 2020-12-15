using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using postgresql.model;

namespace postgresql
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=10.0.0.21;Database=brian;Username=brian;Password=brian1234");
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Query();
           
        }

        private void Query()
        {
            using(var ctx = new sharksContext())
            {

                var q = from o in ctx.Spil
                        select o;
                foreach (var item in q)
                {
                    Console.WriteLine(item.Pris);
                }
            }
        }
    }
}
