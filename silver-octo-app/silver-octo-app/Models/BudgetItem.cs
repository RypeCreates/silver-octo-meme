using System;
namespace silver_octo_app.Models
{
    public class BudgetItem
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
