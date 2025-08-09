using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public class SaleUpdateDto
    {
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
