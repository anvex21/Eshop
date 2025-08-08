using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleDto>> GetAllAsync();
        Task<SaleDto> GetByIdAsync(long id);
        Task<IEnumerable<SaleDto>> GetByClientIdAsync(long clientId);
        Task<IEnumerable<SaleDto>> GetByProductIdAsync(long productId);
        Task<SaleDto> CreateAsync(SaleCreateDto dto);
        Task UpdateAsync(long id, SaleUpdateDto dto);
        Task DeleteAsync(long id);
    }
}
