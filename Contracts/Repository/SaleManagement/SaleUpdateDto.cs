using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
