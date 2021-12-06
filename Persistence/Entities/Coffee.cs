using System;

namespace Persistence.Entities
{
    public class Coffee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
