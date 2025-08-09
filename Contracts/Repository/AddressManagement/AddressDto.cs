using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public long ClientId { get; set; }
        /// <summary>
        /// Country Id
        /// </summary>
        [Required]
        public long CountryId { get; set; }
        /// <summary>
        /// City
        /// </summary>
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        /// <summary>
        /// Street
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        /// <summary>
        /// Number
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Number { get; set; }
        /// <summary>
        /// IsMain
        /// </summary>
        public bool IsMain { get; set; }
    }
}
