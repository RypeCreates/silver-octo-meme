using System;
using System.Collections.Generic;
using silver_octo_app.Models;

namespace silver_octo_app.ViewModels
{
    public class ExpenseFormViewModel
    {
        public ExpenseFormViewModel()
        {

        }

        public IEnumerable<BudgetItem> BudgetItems { get; set; }
        public Expense Expense { get; set; }
    }
}
