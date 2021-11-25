using System;

namespace Persistence.Models.WriteModels
{
    public class CoffeeWriteModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}
