using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using silver_octo_app.ViewModels;
using silver_octo_app.Models;

namespace silver_octo_app.Controllers
{
    public class ExpensesController : Controller
    {
        private ApplicationDbContext _context;

        public ExpensesController()
        {
            this._context = new ApplicationDbContext();
        }

        // TODO: THIS IS USED FOR MIGRATIONS
        //private List<Expense> Expenses = new List<Expense>()
        //{
        //    new Expense {Id = 0, Name = "Latte", ExpenseAmount = (float)4.12, BudgetItemId = 3},
        //    new Expense {Id = 1, Name = "sm Coffee", ExpenseAmount = (float)2.69, BudgetItemId = 3}
        //};


        protected override void Dispose(bool disposing)
        {
            // TODO: Not sure what disposing boolean is supposed to be here.
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var expenses = _context.Expenses.Include(e => e.BudgetItem).ToList();
            //var expenses = _context.Expenses.ToList();

            return View(expenses);
        }

        [Route("Expenses/{id}")]
        public ActionResult Details(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(b => b.Id == id);

            if (expense == null)
            {
                return StatusCode(404);
            }

            return View(expense);
        }


        [Route("Expenses/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(e => e.Id == id);

            if(expense == null)
            {
                return StatusCode(404);
            }

            var categories = _context.BudgetItems.ToList();
            var viewModel = new ExpenseFormViewModel()
            {
                Expense = expense,
                BudgetItems = categories
            };
            ViewBag.Title = "Edit Expense Entry";
            return View("ExpenseForm", viewModel);
        }


        public ActionResult New()
        {
            var viewModel = new ExpenseFormViewModel()
            {
                Expense = new Expense(),
                BudgetItems = _context.BudgetItems.ToList()
            };
            ViewBag.Title = "New Expense Entry";
            return View("ExpenseForm",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return RedirectToAction("Index","Expenses");
        }


        [HttpPost]
        public ActionResult Save(Expense expense)
        {

            if(string.IsNullOrEmpty(expense.Name) || !ModelState.IsValid)
            {
                var viewModel = new ExpenseFormViewModel()
                {
                    Expense = expense,
                    BudgetItems = _context.BudgetItems.ToList()
                };

                return View("ExpenseForm", viewModel);
            }

            if(expense.Id == 0) // if new expense
            {
                _context.Expenses.Add(expense);
            }
            else
            {
                var expenseInDb = _context.Expenses.Single(e => e.Id == expense.Id);
                expenseInDb.Name = expense.Name;
                expenseInDb.ExpenseAmount = expense.ExpenseAmount;
                expenseInDb.ExpenseDate = expense.ExpenseDate;
                expenseInDb.BudgetItem = expense.BudgetItem;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Expenses");
        }
    }
}
