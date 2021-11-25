using Contracts.Models.ResponseModels;
using Persistence.Models.ReadModels;
using Persistence.Models.WriteModels;

namespace Domain
{
    public static class Extensions
    {
        public static CoffeeResponseModel MapToCoffeeResponseFromCoffeeRead(this CoffeeReadModel item)
        {
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
