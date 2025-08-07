using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.AddressManagement
{
    public class AddressDto
    {
        public long ClientId { get; set; }
        public long CountryId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public bool IsMain { get; set; }
    }
}
