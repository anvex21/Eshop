using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.AddressManagement
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<AddressDto> GetAll()
        {
            return _addressRepository.GetAll().Select(Map);
        }

        public AddressDto GetById(long id)
        {
            Address address = _addressRepository.GetById(id);
            return address == null ? null : Map(address);
        }

        public void Create(AddressDto dto)
        {
            Address address = Map(dto);
            _addressRepository.Create(address);
        }

        public void Update(AddressDto dto)
        {
            Address address = Map(dto);
            _addressRepository.Update(address);
        }

        public void Delete(long id)
        {
            Address address = _addressRepository.GetById(id);
            if (address != null)
            {
                _addressRepository.Delete(address);
            }
        }

        public IEnumerable<AddressDto> GetByCountryId(long countryId)
        {
            return _addressRepository.GetAddressesByCountryId(countryId).Select(Map);
        }

        public IEnumerable<AddressDto> GetByClientId(long clientId)
        {
            return _addressRepository.GetAddressesByClientId(clientId).Select(Map);
        }

        private AddressDto Map(Address address) => new()
        {
            Id = address.Id,
            ClientId = address.ClientId,
            CountryId = address.CountryId,
            City = address.City,
            Street = address.Street,
            Number = address.Number,
            IsMain = address.IsMain
        };

        private Address Map(AddressDto dto) => new()
        {
            Id = dto.Id,
            ClientId = dto.ClientId,
            CountryId = dto.CountryId,
            City = dto.City,
            Street = dto.Street,
            Number = dto.Number,
            IsMain = dto.IsMain
        };
    }
}
