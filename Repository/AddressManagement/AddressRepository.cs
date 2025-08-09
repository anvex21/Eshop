using Contracts.Repository.AddressManagement;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AddressManagement
{
    public class AddressRepository : IAddressRepository
    {
        private readonly RepositoryContext _context;

        public AddressRepository(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses
                .Include(a => a.Client)
                .Include(a => a.Country)
                .ToList();
        }

        public Address GetById(long id)
        {
            return _context.Addresses
                .Include(a => a.Client)
                .Include(a => a.Country)
                .FirstOrDefault(a => a.Id == id);
        }

        public void Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public void Delete(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public IEnumerable<Address> GetAddressesByCountryId(long countryId)
        {
            return _context.Addresses
                .Include(a => a.Client)
                .Include(a => a.Country)
                .Where(a => a.CountryId == countryId)
                .ToList();
        }

        public IEnumerable<Address> GetAddressesByClientId(long clientId)
        {
            return _context.Addresses
                .Include(a => a.Client)
                .Include(a => a.Country)
                .Where(a => a.ClientId == clientId)
                .ToList();
        }
    }
}
