using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.AddressManagement
{
    public class AddressDto
    {
        /// <summary>
        /// Address Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Client Id
        /// </summary>
        public long ClientId { get; set; }
        /// <summary>
        /// Country Id
        /// </summary>
        public long CountryId { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Number
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// IsMain
        /// </summary>
        public bool IsMain { get; set; }
    }
}
