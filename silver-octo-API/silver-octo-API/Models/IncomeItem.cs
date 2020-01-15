using System;
namespace silver_octo_API.Models
{
    public class IncomeItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime EntryDate { get; set; }
        public float IncomeAmount { get; set; }
    }
}
