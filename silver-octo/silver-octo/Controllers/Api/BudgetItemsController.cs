using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using silver_octo.Models;
using silver_octo.Data;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace silver_octo.Controllers.Api
{
    [Route("api/BudgetItems")]
    public class BudgetItemsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public BudgetItemsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<BudgetItem> GetBudgetItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.BudgetItems.Where(b => b.ApplicationUserId == userId).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetBudgetItem(long id)
        {
            var budgetItem = _context.BudgetItems.SingleOrDefault(b => b.Id == id);

            if (budgetItem == null)
            {
                return NotFound();
            }
            return Ok(budgetItem);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateBudgetItem([FromBody]BudgetItem budgetItem)
        {
            budgetItem.DateCreated = DateTime.Now;
            budgetItem.DateUpdated = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.BudgetItems.Add(budgetItem);
                _context.SaveChanges();

                return Created("api/BudgetItems/" + budgetItem.Id, budgetItem);
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateBudgetItem(long id, BudgetItem budgetItem)
        {
            budgetItem.DateUpdated = DateTime.Now;

            if (!ModelState.IsValid) throw new Exception();

            var budgetItemInDb = _context.BudgetItems.SingleOrDefault(b => b.Id == id);

            if (budgetItemInDb == null) throw new Exception();

            budgetItemInDb.Amount = budgetItem.Amount;
            budgetItemInDb.CategoryName = budgetItem.CategoryName;
            budgetItemInDb.DateUpdated = budgetItem.DateUpdated;
            budgetItemInDb.Description = budgetItem.Description;

            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteBudgetItem(long id)
        {
            if (!ModelState.IsValid) throw new Exception();

            var budgetItemInDb = _context.BudgetItems.SingleOrDefault(b => b.Id == id);

            if (budgetItemInDb == null) throw new Exception();

            _context.BudgetItems.Remove(budgetItemInDb);
            _context.SaveChanges();
        }
    }
}
