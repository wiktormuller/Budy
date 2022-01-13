using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Domain.Entities;

namespace Budy.Application.Interfaces
{
    public interface IExpensesRepository
    {
        Task<Expense> GetById(int id);
        Task<List<Expense>> GetAll();
        Task<int> Create(Expense category);
        Task Update();
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}