using Contracts.Repository.SaleManagement;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Repository.ProductManagement;

namespace Eshop.Controllers.SaleManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Gets all sales
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSales")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<SaleDto> sales = await _saleService.GetAllAsync();
            return Ok(sales);
        }

        /// <summary>
        /// Get sale by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetSaleById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            SaleDto sale = await _saleService.GetByIdAsync(id);
            return Ok(sale);
        }


        /// <summary>
        /// Get sale by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("GetSaleByClientId/{clientId}")]
        public async Task<IActionResult> GetByClientId(long clientId)
        {
            IEnumerable<SaleDto> sales = await _saleService.GetByClientIdAsync(clientId);
            return Ok(sales);
        }


        /// <summary>
        /// Get sale by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("GetSaleByProductId/{productId}")]
        public async Task<IActionResult> GetByProductId(long productId)
        {
            IEnumerable<SaleDto> sales = await _saleService.GetByProductIdAsync(productId);
            return Ok(sales);
        }


        /// <summary>
        /// Add a sale
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddSale")]
        public async Task<IActionResult> Create(SaleCreateDto dto)
        {
            SaleDto sale = await _saleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        }

        /// <summary>
        /// Update a sale
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPut("UpdateSale/{id}")]
        public async Task<IActionResult> Update(long id, SaleUpdateDto dto)
        {
            await _saleService.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Delete a sale
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("DeleteSale/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _saleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
