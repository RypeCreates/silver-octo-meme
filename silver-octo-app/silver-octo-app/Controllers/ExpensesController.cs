using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        protected override void Dispose(bool disposing)
        {
            // TODO: Not sure what disposing boolean is supposed to be here.
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var expenses = _context.Expenses.ToList();

            return View(expenses);
        }

        [Route("expenses/{id}")]
        public ActionResult Details(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(b => b.Id == id);

            if (expense == null)
            {
                return StatusCode(404);
            }

            return View(expense);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}
