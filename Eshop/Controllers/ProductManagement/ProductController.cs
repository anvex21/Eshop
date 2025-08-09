using Contracts.DTOs.Product;
using Contracts.Repository.ProductManagement;
using Contracts.Services.ProductManagement;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers.ProductManagement;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    /// <summary>
    /// Repository for Product domain object
    /// </summary>
    private readonly IProductRepository productRepository;
    private readonly IProductService productService;


    /// <summary>
    /// Initializes a new instance of <see cref="ProductController"/> class.
    /// </summary>
    /// <param name="productRepository">The Product repository.</param>
    public ProductController(IProductRepository productRepository, IProductService productService)
    {
        this.productRepository = productRepository;
        this.productService = productService;
    }

    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetAllProducts")]
    public IActionResult GetAll()
    {
        IEnumerable<Product> allProducts = productRepository.GetAll();

        if (!allProducts.Any())
        {
            return NotFound("No products found.");
        }

        return Ok(allProducts);
    }

    /// <summary>
    /// Gets product by ID
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetProductById(long id)
    {
        Product product = productRepository.GetById(id);

        if (product is null)
        {
            return NotFound("Product not found.");
        }

        return Ok(product);
    }

    /// <summary>
    /// Adds new product
    /// </summary>
    /// <param name="product">Product object</param>
    /// <returns></returns>
    [HttpPost("AddProduct")]
    public IActionResult AddProduct(ProductCreateDto dto)
    {
        Product product = productService.CreateProductFromDto(dto);
        productRepository.Create(product);

        return Ok(product);
    }


    /// <summary>
    /// Updates an existing product
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <param name="dto">Product update DTO</param>
    /// <returns></returns>
    [HttpPut("UpdateProduct/{id}")]
    public IActionResult UpdateProduct(long id, ProductUpdateDto dto)
    {
        Product product = productRepository.GetById(id);
        if (product is null)
        {
            return NotFound("Product not found.");
        }

        product.Name = dto.Name;
        product.Type = dto.Type;
        product.Price = dto.Price;

        productRepository.Update(product);

        return Ok(product);
    }
    /// <summary>
    /// Deletes a product by ID
    /// </summary>
    /// <param name="id">Product ID</param>
    /// <returns></returns>
    [HttpDelete("DeleteProduct/{id}")]
    public IActionResult DeleteProduct(long id)
    {
        var product = productRepository.GetById(id);
        if (product is null)
        {
            return NotFound("Product not found.");
        }

        productRepository.Delete(product);
        return Ok($"Product with ID {id} deleted.");
    }
    /// <summary>
    /// Gets all products of a specific type
    /// </summary>
    /// <param name="type">Product type</param>
    /// <returns></returns>
    [HttpGet("GetByType")]
    public IActionResult GetByType(string type)
    {
        IEnumerable<Product> products = productRepository.GetAll().Where(p => p.Type.ToLower() == type);

        if (!products.Any())
        {
            return NotFound($"No products of type '{type}' found.");
        }

        return Ok(products);
    }

    /// <summary>
    /// Returns the products sorted by their price, ascending
    /// </summary>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    [HttpGet("SortedByPrice")]
    public IActionResult GetAllProductsSortedByPrice()
    {
        IEnumerable<Product> products = productRepository.GetAll();
        if (!products.Any())
        {
            return NotFound("No products found.");
        }
        products = products.OrderBy(p => p.Price).ToList();
        return Ok(products);
    }
}