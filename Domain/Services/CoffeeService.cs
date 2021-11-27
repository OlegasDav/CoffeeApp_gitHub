using Contracts.Models.RequestModels;
using Contracts.Models.ResponseModels;
using Persistence.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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
            var coffeeItems = await _coffeeRepository.GetAllAsync();

            return coffeeItems.Select(item => item.MapToCoffeeResponseFromCoffee());
        }

        public async Task<CoffeeResponseModel> AddAsync(CoffeeRequestModel request)
        {
            var fileNameSplit = request.Image.FileName.Split(".");
            var extension = "." + fileNameSplit[^1];
            var fileName = DateTime.Now.Ticks + extension;
            var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), @"..\Upload\images");

            if (!Directory.Exists(pathBuilt))
            {
                Directory.CreateDirectory(pathBuilt);
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"..\Upload\images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.Image.CopyToAsync(stream);
            }

            var coffee = new Coffee
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Image = fileName
            };

            await _coffeeRepository.SaveAsync(coffee);

            return coffee.MapToCoffeeResponseFromCoffee();
        }

        public async Task RemoveAsync(Guid id)
        {
            await _coffeeRepository.DeleteAsync(id);
        }
    }
}
