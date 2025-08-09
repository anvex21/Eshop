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

        // Constructor
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // Returns all addresses in the database
        public IEnumerable<AddressDto> GetAll()
        {
            return _addressRepository.GetAll().Select(Map);
        }

        // Returns deails about the address by its id  
        public AddressDto GetById(long id)
        {
            Address address = _addressRepository.GetById(id);
            return address == null ? null : Map(address);
        }

        // Creates a new address

        public void Create(AddressDto dto)
        {
            Address address = Map(dto);
            _addressRepository.Create(address);
        }

        // Updates an address

        public void Update(AddressDto dto)
        {
            Address address = Map(dto);
            _addressRepository.Update(address);
        }

        // Deletes an address by finding it through its id
        public void Delete(long id)
        {
            Address address = _addressRepository.GetById(id);
            if (address != null)
            {
                _addressRepository.Delete(address);
            }
        }

        // Returns details about an address by a country's id

        public IEnumerable<AddressDto> GetByCountryId(long countryId)
        {
            return _addressRepository.GetAddressesByCountryId(countryId).Select(Map);
        }

        // Returns details about an address by a client's id

        public IEnumerable<AddressDto> GetByClientId(long clientId)
        {
            return _addressRepository.GetAddressesByClientId(clientId).Select(Map);
        }

        // mapping

        private AddressDto Map(Address address) => new()
        {
            ClientId = address.ClientId,
            CountryId = address.CountryId,
            City = address.City,
            Street = address.Street,
            Number = address.Number,
            IsMain = address.IsMain
        };

        // mapping with the dto

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
