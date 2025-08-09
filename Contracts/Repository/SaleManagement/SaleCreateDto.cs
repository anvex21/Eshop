using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public class SaleCreateDto
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public long ClientId { get; set; }
        /// <summary>
        /// Product Id
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// OrderDate
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
