using Microsoft.AspNetCore.Http;

namespace Contracts.Models.RequestModels
{
    public class CoffeeRequestModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        //public string Image { get; set; }
        public IFormFile Image { get; set; }
    }
}
