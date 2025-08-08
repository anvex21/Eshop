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

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .ToListAsync();
        }

        public async Task<Sale> GetByIdAsync(long id)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sale>> GetByClientIdAsync(long clientId)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Where(s => s.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetByProductIdAsync(long productId)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Product)
                .Where(s => s.ProductId == productId)
                .ToListAsync();
        }

        public async Task<Sale> CreateAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

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
