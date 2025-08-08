using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.SaleManagement
{
    public class SaleDto
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
