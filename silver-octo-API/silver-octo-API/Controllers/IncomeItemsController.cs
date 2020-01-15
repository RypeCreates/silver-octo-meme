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
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeItemsController : ControllerBase
    {
        private readonly IncomeContext _context;

        public IncomeItemsController(IncomeContext context)
        {
            _context = context;
        }

        // GET: api/IncomeItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeItem>>> GetIncomeItems()
        {
            return await _context.IncomeItems.ToListAsync();
        }

        // GET: api/IncomeItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeItem>> GetIncomeItem(long id)
        {
            var incomeItem = await _context.IncomeItems.FindAsync(id);

            if (incomeItem == null)
            {
                return NotFound();
            }

            return incomeItem;
        }

        // PUT: api/IncomeItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncomeItem(long id, IncomeItem incomeItem)
        {
            if (id != incomeItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(incomeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IncomeItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<IncomeItem>> PostIncomeItem(IncomeItem incomeItem)
        {
            _context.IncomeItems.Add(incomeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIncomeItem), new { id = incomeItem.Id }, incomeItem);
        }

        // DELETE: api/IncomeItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncomeItem>> DeleteIncomeItem(long id)
        {
            var incomeItem = await _context.IncomeItems.FindAsync(id);
            if (incomeItem == null)
            {
                return NotFound();
            }

            _context.IncomeItems.Remove(incomeItem);
            await _context.SaveChangesAsync();

            return incomeItem;
        }

        private bool IncomeItemExists(long id)
        {
            return _context.IncomeItems.Any(e => e.Id == id);
        }
    }
}
