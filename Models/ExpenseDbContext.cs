using Microsoft.EntityFrameworkCore;

namespace EveningExpenseTracker.Models
{
    public class ExpenseDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
            
        }
    }

  
}
