using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Sex/Gender
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// AddressIds of the Client, a list
        /// </summary>
        public List<long> AddressIds { get; set; }
    }
}
