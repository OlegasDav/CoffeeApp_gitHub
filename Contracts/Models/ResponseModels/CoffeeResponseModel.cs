using System;

namespace Contracts.Models.ResponseModels
{
    public class CoffeeResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}
