using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        // Constructor
        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        // Gets all the sales from the databse, synchronously
        public async Task<IEnumerable<SaleDto>> GetAllAsync()
        {
            IEnumerable<Sale> sales = await _saleRepository.GetAllAsync();
            return sales.Select(MapToDto);
        }

        // Returns details about a sale by its id, synchronously 
        public async Task<SaleDto> GetByIdAsync(long id)
        {
            Sale sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null) throw new KeyNotFoundException("Sale not found.");
            return MapToDto(sale);
        }

        // Returns details about a sale by the client's id, synchronously 

        public async Task<IEnumerable<SaleDto>> GetByClientIdAsync(long clientId)
        {
            IEnumerable<Sale> sales = await _saleRepository.GetByClientIdAsync(clientId);
            return sales.Select(MapToDto);
        }

        // Returns details about a sale by the product's id, synchronously 

        public async Task<IEnumerable<SaleDto>> GetByProductIdAsync(long productId)
        {
            IEnumerable<Sale> sales = await _saleRepository.GetByProductIdAsync(productId);
            return sales.Select(MapToDto);
        }

        // Creates a sale

        public async Task<SaleDto> CreateAsync(SaleCreateDto dto)
        {
            Sale sale = new Sale
            {
                ClientId = dto.ClientId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                OrderDate = dto.OrderDate
            };

            Sale createdSale = await _saleRepository.CreateAsync(sale);
            return MapToDto(createdSale);
        }
        
        // Updates a sale

        public async Task UpdateAsync(long id, SaleUpdateDto dto)
        {
            Sale sale = await _saleRepository.GetByIdAsync(id);
            if (sale is null) throw new KeyNotFoundException("Sale not found.");

            sale.Quantity = dto.Quantity;
            sale.OrderDate = dto.OrderDate;

            await _saleRepository.UpdateAsync(sale);
        }

        // Deletes a sale
        public async Task DeleteAsync(long id)
        {
            Sale sale = await _saleRepository.GetByIdAsync(id);
            if (sale is null) throw new KeyNotFoundException("Sale not found.");

            await _saleRepository.DeleteAsync(sale);
        }

        // Mapping

        private SaleDto MapToDto(Sale sale)
        {
            return new SaleDto
            {
                Id = sale.Id,
                ClientId = sale.ClientId,
                ClientName = sale.Client.FirstName,
                ProductId = sale.ProductId,
                ProductName = sale.Product?.Name,
                Quantity = sale.Quantity,
                OrderDate = sale.OrderDate
            };
        }
    }
}
