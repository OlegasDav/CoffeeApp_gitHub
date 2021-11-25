using Contracts.Models.RequestModels;
using Contracts.Models.ResponseModels;
using Persistence.Models.WriteModels;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<IEnumerable<CoffeeResponseModel>> GetAllAsync()
        {
            var coffee = await _coffeeRepository.GetAllAsync();

            return coffee.Select(item => item.MapToCoffeeResponseFromCoffeeRead());
        }

        public async Task<CoffeeResponseModel> AddAsync(CoffeeRequestModel request)
        {
            var coffee = new CoffeeWriteModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Image = request.Image.FileName
            };

            await _coffeeRepository.SaveAsync(coffee);

            return coffee.MapToCoffeeResponseFromCoffeeWrite();
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            return await _coffeeRepository.DeleteAsync(id);
        }
    }
}
