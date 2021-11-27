using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface ICoffeeRepository
    {
        Task<IEnumerable<Coffee>> GetAllAsync();

        Task SaveAsync(Coffee model);

        Task DeleteAsync(Guid id);
    }
}
