using Contracts.DTOs.Product;
using Contracts.Services.ProductManagement;
using Entities;

namespace Services.ProductManagement
{
    public class ProductService : IProductService
    {
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