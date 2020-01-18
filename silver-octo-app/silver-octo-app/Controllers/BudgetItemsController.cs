using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using silver_octo_app.Models;

namespace silver_octo_app.Controllers
{
    public class BudgetItemsController : Controller
    {
        // Get: BudgetItems/Random
        public ViewResult Random()
        {
            var budgetItem = new BudgetItem()
            {
                Amount = 1.00,
                Category = "coffee",
                Description ="all the caffeine I can spend."
            };
            return View(budgetItem);

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if(string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Category";
            }

            return Content(string.Format("pageIndex={0}@sortBy={1}", pageIndex, sortBy));
        }

        [Route("budgetItems/entered/{month:range(1,12)}/{day}")]
        public ActionResult ByEntryDate(int month, int day)
        {
            return Content(string.Format("{0}/{1}",month,day));
        }

        [Route("budgetItems/categories/{category}")]
        public ActionResult ByCategory(string category)
        {
            List<BudgetItem> BudgetList = new List<BudgetItem>();

            return View(BudgetList);
        }
    }
}
