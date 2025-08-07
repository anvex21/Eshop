using Contracts.Repository.ProductManagement;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;

namespace Repository.ProductManagement;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }

    
}
