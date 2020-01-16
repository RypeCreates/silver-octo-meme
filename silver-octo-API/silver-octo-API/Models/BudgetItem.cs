using System;
namespace silver_octo_API.Models
{
    public class BudgetItem
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
