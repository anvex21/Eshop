using Contracts.DTOs.Product;
using Entities;

namespace Contracts.Services.ProductManagement
{
    public interface IProductService
    {
        Product CreateProductFromDto(ProductCreateDto dto);
    }
}
