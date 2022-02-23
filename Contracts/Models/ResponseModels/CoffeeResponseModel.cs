using System;

namespace Contracts.Models.ResponseModels
{
    public class CoffeeResponseModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The name of coffee
        /// </summary>
        /// <example>Cappuccino</example>
        public string Name { get; set; }

        /// <summary>
        /// The price of coffee
        /// </summary>
        ///<example>1.89</example>
        public decimal Price { get; set; }

        public string Image { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
