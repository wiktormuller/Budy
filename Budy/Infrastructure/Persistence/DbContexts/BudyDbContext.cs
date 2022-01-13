using Budy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Budy.Infrastructure.Persistence.DbContexts
{
    public class BudyDbContext : DbContext
    {
        public BudyDbContext()
        {
            
        }

        public BudyDbContext(DbContextOptions<BudyDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}