using System;
namespace silver_octo_app.Models
{
    // NOTE: This model is currently deprecated
    public class IncomeItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float IncomeAmount { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime IncomeDate { get; set; }
    }
}
