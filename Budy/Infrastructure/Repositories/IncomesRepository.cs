using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Application.Interfaces;
using Budy.Domain.Entities;
using Budy.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Budy.Infrastructure.Repositories
{
    public class IncomesRepository : IIncomesRepository
    {
        private readonly BudyDbContext _context;

        public IncomesRepository(BudyDbContext context)
        {
            _context = context;
        }
        
        public async Task<Income> GetById(int id)
        {
            return await _context.Incomes
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Income>> GetAll()
        {
            return await _context.Incomes
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<int> Create(Income income)
        {
            await _context.Incomes.AddAsync(income);
            await _context.SaveChangesAsync();

            return income.Id;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var income = await GetById(id);
            _context.Remove(income);
            
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await GetById(id) is not null;
        }
    }
}