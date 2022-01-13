using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Domain.Entities;

namespace Budy.Application.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<Category> GetById(int id);
        Task<List<Category>> GetAll();
        Task<int> Create(Category category);
        Task Update();
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}