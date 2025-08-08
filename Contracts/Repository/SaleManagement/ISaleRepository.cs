using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> GetByIdAsync(long id);
        Task<IEnumerable<Sale>> GetByClientIdAsync(long clientId);
        Task<IEnumerable<Sale>> GetByProductIdAsync(long productId);
        Task<Sale> CreateAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(Sale sale);
        Task<bool> ExistsAsync(long id);
    }
}
