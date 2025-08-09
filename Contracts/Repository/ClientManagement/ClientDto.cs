using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.ClientManagement
{
    public class ClientDto
    {
        /// <summary>
        /// Client Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// First Name 
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        /// <summary>
        /// Age
        /// </summary>
        [Required]
        [Range(0,120)]
        public int Age { get; set; }
        /// <summary>
        /// Sex/Gender
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Sex { get; set; }
        /// <summary>
        /// AddressIds of the Client, a list
        /// </summary>
        public List<long> AddressIds { get; set; }
    }
}
