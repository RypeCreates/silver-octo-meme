using System;
namespace silver_octo_app.Models
{
    // NOTE: This model is currently deprecated
    public class ExpenseItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }    // FK reference to categories table
        public float ExpenseAmount { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
