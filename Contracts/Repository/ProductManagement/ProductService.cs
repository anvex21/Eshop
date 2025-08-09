using Contracts.DTOs.Product;
using Contracts.Services.ProductManagement;
using Entities;

namespace Services.ProductManagement
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Product CreateProductFromDto(ProductCreateDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Type = dto.Type,
                Price = dto.Price
            };
        }
    }
}