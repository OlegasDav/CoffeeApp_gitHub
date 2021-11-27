using Contracts.Models.RequestModels;
using Contracts.Models.ResponseModels;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("coffee")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeResponseModel>>> GetAll()
        {
            var coffeeItems = await _coffeeService.GetAllAsync();

            return Ok(coffeeItems);
        }

        [HttpPost]
        public async Task<ActionResult<CoffeeResponseModel>> Add([FromForm] CoffeeRequestModel requestModel)
        {
            var coffee = await _coffeeService.AddAsync(requestModel);

            return Ok(coffee);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            await _coffeeService.RemoveAsync(id);

            return NoContent();
        }
    }
}
