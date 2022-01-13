using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Application.Interfaces;
using Budy.Domain.Entities;
using Budy.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Budy.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly BudyDbContext _context;

        public CategoriesRepository(BudyDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<int> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = await GetById(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await GetById(id) is not null;
        }
    }
}