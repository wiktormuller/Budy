using Budy.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Budy.Infrastructure.Persistence.DbContexts
{
    public class BudyDbContext : IdentityDbContext<User, Role, int>
    {
        public BudyDbContext()
        {
            
        }

        public BudyDbContext(DbContextOptions<BudyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}