using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface ICoffeeRepository
    {
        Task<IEnumerable<CoffeeReadModel>> GetAllAsync();

        Task<int> SaveAsync(CoffeeWriteModel model);

        Task<int> DeleteAsync(Guid id);
    }
}
