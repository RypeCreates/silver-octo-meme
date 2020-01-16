using System;
using Microsoft.EntityFrameworkCore;
using silver_octo_API.Models;
namespace silver_octo_API.Models
{
    public class BudgetContext: DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options)
            : base(options)
        {
        }
        public DbSet<silver_octo_API.Models.BudgetItem> BudgetItem { get; set; }
    }
}
