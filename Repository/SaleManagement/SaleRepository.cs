using Contracts.Repository.SaleManagement;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SaleManagement
{
    public class SaleRepository : ISaleRepository
    {
        private readonly RepositoryContext _context;

        public SaleRepository(RepositoryContext context)
        {
            _context = context;
        }

        // Gets all sales

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .ToListAsync();
        }

        // Gets a sale by its id

        public async Task<Sale> GetByIdAsync(long id)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Gets a sale by the client's id

        public async Task<IEnumerable<Sale>> GetByClientIdAsync(long clientId)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Where(s => s.ClientId == clientId)
                .ToListAsync();
        }

        // Gets a sale by the product's id
        public async Task<IEnumerable<Sale>> GetByProductIdAsync(long productId)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Where(s => s.ProductId == productId)
                .ToListAsync();
        }

        // Creates a sale
        public async Task<Sale> CreateAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        // Updates a sale

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        // Deletes a sale

        public async Task DeleteAsync(Sale sale)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ExistsAsync(long id)
        {
            return await _context.Sales.AnyAsync(s => s.Id == id);
        }
    }
}
