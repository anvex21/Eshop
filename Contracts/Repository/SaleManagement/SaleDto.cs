using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public class SaleDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// ClientId
        /// </summary>
        public long ClientId { get; set; }
        /// <summary>
        /// ClientName
        /// </summary>
        public string ClientName { get; set; }
        /// <summary>
        /// ProductId
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; }
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
