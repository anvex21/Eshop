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

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<IEnumerable<SaleDto>> GetAllAsync()
        {
            IEnumerable<Sale> sales = await _saleRepository.GetAllAsync();
            return sales.Select(MapToDto);
        }

        public async Task<SaleDto> GetByIdAsync(long id)
        {
            Sale sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null) throw new KeyNotFoundException("Sale not found.");
            return MapToDto(sale);
        }

        public async Task<IEnumerable<SaleDto>> GetByClientIdAsync(long clientId)
        {
            IEnumerable<Sale> sales = await _saleRepository.GetByClientIdAsync(clientId);
            return sales.Select(MapToDto);
        }

        public async Task<IEnumerable<SaleDto>> GetByProductIdAsync(long productId)
        {
            IEnumerable<Sale> sales = await _saleRepository.GetByProductIdAsync(productId);
            return sales.Select(MapToDto);
        }

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

        public async Task UpdateAsync(long id, SaleUpdateDto dto)
        {
            Sale sale = await _saleRepository.GetByIdAsync(id);
            if (sale is null) throw new KeyNotFoundException("Sale not found.");

            sale.Quantity = dto.Quantity;
            sale.OrderDate = dto.OrderDate;

            await _saleRepository.UpdateAsync(sale);
        }

        public async Task DeleteAsync(long id)
        {
            Sale sale = await _saleRepository.GetByIdAsync(id);
            if (sale is null) throw new KeyNotFoundException("Sale not found.");

            await _saleRepository.DeleteAsync(sale);
        }

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
