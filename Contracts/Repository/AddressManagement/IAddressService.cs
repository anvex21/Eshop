using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.AddressManagement
{
    public interface IAddressService
    {
        IEnumerable<AddressDto> GetAll();
        AddressDto GetById(long id);
        void Create(AddressDto dto);
        void Update(AddressDto dto);
        void Delete(long id);
        IEnumerable<AddressDto> GetByCountryId(long countryId);
        IEnumerable<AddressDto> GetByClientId(long clientId);
    }
}
