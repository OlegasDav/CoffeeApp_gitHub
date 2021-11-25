using System;

namespace Persistence.Models.ReadModels
{
    public class CoffeeReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}
