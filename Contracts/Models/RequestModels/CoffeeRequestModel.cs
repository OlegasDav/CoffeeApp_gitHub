using Contracts.Extensions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Models.RequestModels
{
    public class CoffeeRequestModel
    {
        /// <summary>
        /// The name of coffee
        /// </summary>
        /// <example>Cappuccino</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The price of coffee
        /// </summary>
        ///<example>1.89</example>
        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxFileSize(100 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile Image { get; set; }
    }
}
