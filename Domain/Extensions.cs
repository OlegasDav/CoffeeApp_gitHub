using Contracts.Models.ResponseModels;
using Persistence.Entities;
using System;
using System.IO;

namespace Domain
{
    public static class Extensions
    {
        public static CoffeeResponseModel MapToCoffeeResponseFromCoffee(this Coffee item)
        {
            var image = item.Image;

            try
            {
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Upload\images", item.Image);
                var fileBytes = File.ReadAllBytes(filepath);
                image = Convert.ToBase64String(fileBytes);
            }
            catch { }

            return new CoffeeResponseModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Image = image
            };
        }
    }
}
