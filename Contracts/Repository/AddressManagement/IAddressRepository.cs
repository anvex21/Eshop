using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.AddressManagement
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address GetById(long id);
        void Create(Address address);
        void Update(Address address);
        void Delete(Address address);
        IEnumerable<Address> GetAddressesByCountryId(long countryId);
        IEnumerable<Address> GetAddressesByClientId(long clientId);
    }
}
