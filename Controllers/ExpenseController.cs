using Microsoft.AspNetCore.Mvc;
using CinemaCalcAPI.Models;
using CinemaCalcAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly CinemaCalcContext _context;

        public ExpenseController(CinemaCalcContext context)
        {
            _context = context;
        }

        // GET: api/expense
        [HttpGet]
        public async Task<ActionResult<object>> GetExpenses()
        {
            var expenses = await _context.Expenses.ToListAsync();
            var totalExpenses = expenses.Sum(e => e.Price + (e.Price * e.PercentageMarkup / 100));

            return Ok(new
            {
                TotalExpenses = totalExpenses,
                ExpensesList = expenses
            });
        }

        // GET: api/expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound(new { message = "Expense not found" });
            }

            return Ok(expense);
        }

        // POST: api/expense
        [HttpPost]
        public async Task<ActionResult> PostExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, new { message = "Expense added", expense });
        }

        // PUT: api/expense/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest(new { message = "Expense ID mismatch" });
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound(new { message = "Expense not found" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Expense updated", expense });
        }

        // DELETE: api/expense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound(new { message = "Expense not found" });
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Expense deleted" });
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
