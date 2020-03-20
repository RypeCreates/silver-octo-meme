using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using silver_octo_app.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace silver_octo_app.Controllers.Api
{
    [Route("api/Expenses")]
    public class ExpensesController : ControllerBase
    {

        private ApplicationDbContext _context;

        public ExpensesController()
        {
            this._context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Expense> GetExpenses()
        {
            return _context.Expenses.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetExpense(long id)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.Id == id);

            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public IActionResult CreateExpense([FromBody]Expense expense)
        {

            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();

                return Created("api/Expenses/" + expense.Id, expense);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public void UpdateExpense(long id, Expense expense)
        {
            if (!ModelState.IsValid) throw new Exception();

            var expenseInDb = _context.Expenses.SingleOrDefault(e => e.Id == id);

            if (expenseInDb == null) throw new Exception();

            expenseInDb.Name = expense.Name;
            expenseInDb.ExpenseDate = expense.ExpenseDate;
            expenseInDb.ExpenseAmount = expense.ExpenseAmount;
            expenseInDb.BudgetItemId = expense.BudgetItemId;

            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteExpense(long id)
        {
            if (!ModelState.IsValid) throw new Exception();

            var expenseInDb = _context.Expenses.SingleOrDefault(e => e.Id == id);

            if (expenseInDb == null) throw new Exception();

            _context.Expenses.Remove(expenseInDb);
        }
    }
}
