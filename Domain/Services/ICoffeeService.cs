using Contracts.Models.RequestModels;
using Contracts.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICoffeeService
    {
        Task<IEnumerable<CoffeeResponseModel>> GetAllAsync();

        Task<CoffeeResponseModel> AddAsync(CoffeeRequestModel request);

        Task RemoveAsync(Guid id);
    }
}
