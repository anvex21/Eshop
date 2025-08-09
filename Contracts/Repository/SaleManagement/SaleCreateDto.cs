using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public long ClientId { get; set; }
        /// <summary>
        /// Product Id
        /// </summary>
        [Required]
        public long ProductId { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Quantity { get; set; }
        /// <summary>
        /// OrderDate
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
    }
}
