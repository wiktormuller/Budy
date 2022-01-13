using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Application.Interfaces;
using Budy.Domain.Entities;
using Budy.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Budy.Infrastructure.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly BudyDbContext _context;

        public ExpensesRepository(BudyDbContext context)
        {
            _context = context;
        }
        
        public async Task<Expense> GetById(int id)
        {
            return await _context.Expenses
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Expense>> GetAll()
        {
            return await _context.Expenses
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<int> Create(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();

            return expense.Id;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var expense = await GetById(id);
            _context.Remove(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await GetById(id) is not null;
        }
    }
}