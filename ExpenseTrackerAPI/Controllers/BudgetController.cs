using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly ExpenseTrackerDbContext _context;

        public BudgetController(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<Budget>> GetBudget(int userId)
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.UserId == userId);
            if (budget == null)
            {
                return NotFound();
            }
            return budget;
        }

        [HttpPost]
        public async Task<ActionResult<Budget>> SetBudget(Budget budget)
        {
            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBudget), new { id = budget.Id }, budget);
        }
    }
}
