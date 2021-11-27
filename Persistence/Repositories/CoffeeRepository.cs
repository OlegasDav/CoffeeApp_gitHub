using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly CoffeeContext _dbContext;

        public CoffeeRepository(CoffeeContext coffeeContext)
        {
            _dbContext = coffeeContext;
        }

        public async Task<Coffee> GetAsync(Guid id)
        {
            var coffeeItem = await _dbContext.Coffee.FirstOrDefaultAsync(item => item.Id == id);

            return coffeeItem;
        }

        public async Task<IEnumerable<Coffee>> GetAllAsync()
        {
            var coffeeItems = await _dbContext.Coffee.ToListAsync();

            return coffeeItems;
        }

        public async Task SaveAsync(Coffee model)
        {
            await _dbContext.Coffee.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var coffeeItem = await _dbContext.Coffee.FirstOrDefaultAsync(item => item.Id == id);

            _dbContext.Coffee.Remove(coffeeItem);

            await _dbContext.SaveChangesAsync();
        }
    }
}
