using Microsoft.EntityFrameworkCore;
using silver_octo_app.Models;

namespace silver_octo_app
{
    public class ApplicationDbContext : DbContext
    {
        // These DbSets create database tables based on the Models classes in the Models folder.
        public DbSet<Category> Categories { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=silverOcto.db");

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
                {
                }
    }


    //public class Blog
    //{
    //    public int BlogId { get; set; }
    //    public string Url { get; set; }

    //    public List<Post> Posts { get; } = new List<Post>();
    //}

    //public class Post
    //{
    //    public int PostId { get; set; }
    //    public string Title { get; set; }
    //    public string Content { get; set; }

    //    public int BlogId { get; set; }
    //    public Blog Blog { get; set; }
    //}
}