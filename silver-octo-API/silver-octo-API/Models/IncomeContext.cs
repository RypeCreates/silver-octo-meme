using System;
using Microsoft.EntityFrameworkCore;

namespace silver_octo_API.Models
{
    public class IncomeContext : DbContext
    {
        public IncomeContext(DbContextOptions<IncomeContext> options)
            : base(options)
        {
        }

        public DbSet<IncomeItem> IncomeItems { get; set; }
    }
}
