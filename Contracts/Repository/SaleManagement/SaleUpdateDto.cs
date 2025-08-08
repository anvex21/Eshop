using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public class SaleUpdateDto
    {
        public double Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
