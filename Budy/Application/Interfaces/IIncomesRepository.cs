using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Domain.Entities;

namespace Budy.Application.Interfaces
{
    public interface IIncomesRepository
    {
        Task<Domain.Entities.Income> GetById(int id);
        Task<List<Domain.Entities.Income>> GetAll();
        Task<int> Create(Domain.Entities.Income category);
        Task Update();
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}