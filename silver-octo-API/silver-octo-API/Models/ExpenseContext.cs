using System;
using Microsoft.EntityFrameworkCore;

namespace silver_octo_API.Models
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseItem> ExpenseItems { get; set; }
    }
}
