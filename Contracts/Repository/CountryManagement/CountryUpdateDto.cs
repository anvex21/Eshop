using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.CountryManagement
{
    public class CountryUpdateDto
    {
        public string IsoName { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string PhoneCode { get; set; }
    }
}
