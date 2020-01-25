using Microsoft.EntityFrameworkCore;
using silver_octo_app.Models;
using Microsoft.Extensions.DependencyInjection;

namespace silver_octo_app
{
    public class ApplicationDbContext : DbContext
    {
        // These DbSets create database tables based on the Models classes in the Models folder.
        public DbSet<Category> Categories { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Data Source=silverOcto.db");
            options.UseSqlServer("Server=localhost,1401;Database=silverOctoDB;User=sa;Password=YourStrong!Passw0rd;Trusted_Connection=False;MultipleActiveResultSets=true");
        }
        // TODO : Figure out how to resolve these hard-coded configuration strings.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext> (options =>
                options.UseSqlServer("Server=localhost,1401;Database=silverOctoDB;User=sa;Password=YourStrong!Passw0rd;Trusted_Connection=False;MultipleActiveResultSets=true"));
        }

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