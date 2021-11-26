using Contracts.Models.ResponseModels;
using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;
using System;
using System.IO;

namespace Domain
{
    public static class Extensions
    {
        public static CoffeeResponseModel MapToCoffeeResponseFromCoffeeRead(this CoffeeReadModel item)
        {
            try
            {
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Upload\images", item.Image);
                var fileBytes = File.ReadAllBytes(filepath);
                item.Image = Convert.ToBase64String(fileBytes);
            }
            catch { }

            return new CoffeeResponseModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Image = item.Image
            };
        }

        public static CoffeeResponseModel MapToCoffeeResponseFromCoffeeWrite(this CoffeeWriteModel item)
        {
            try
            {
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Upload\images", item.Image);
                var fileBytes = File.ReadAllBytes(filepath);
                item.Image = Convert.ToBase64String(fileBytes);
            }
            catch { }

            return new CoffeeResponseModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Image = item.Image
            };
        }
    }
}
