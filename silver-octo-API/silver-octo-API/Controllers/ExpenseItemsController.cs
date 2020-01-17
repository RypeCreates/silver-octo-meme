using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silver_octo_API.Models;

namespace silver_octo_API.Controllers
{
    [Route("api/ExpenseItems")]
    [ApiController]
    public class ExpenseItemsController : ControllerBase
    {
        private readonly ExpenseContext _context;

        public ExpenseItemsController(ExpenseContext context)
        {
            _context = context;
        }

        // GET: api/ExpenseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseItem>>> GetExpenseItems()
        {
            return await _context.ExpenseItems.ToListAsync();
        }

        // GET: api/ExpenseItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseItem>> GetExpenseItem(long id)
        {
            var expenseItem = await _context.ExpenseItems.FindAsync(id);

            if (expenseItem == null)
            {
                return NotFound();
            }

            return expenseItem;
        }

        // PUT: api/ExpenseItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseItem(long id, ExpenseItem expenseItem)
        {
            if (id != expenseItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenseItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!ExpenseItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }

            return NoContent();
        }

        // POST: api/ExpenseItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ExpenseItem>> PostExpenseItem(ExpenseItem expenseItem)
        {
            _context.ExpenseItems.Add(expenseItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenseItem", new { id = expenseItem.Id }, expenseItem);
        }

        // DELETE: api/ExpenseItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExpenseItem>> DeleteExpenseItem(long id)
        {
            var expenseItem = await _context.ExpenseItems.FindAsync(id);
            if (expenseItem == null)
            {
                return NotFound();
            }

            _context.ExpenseItems.Remove(expenseItem);
            await _context.SaveChangesAsync();

            return expenseItem;
        }

        private bool ExpenseItemExists(long id)
        {
            return _context.ExpenseItems.Any(e => e.Id == id);
        }
    }
}
