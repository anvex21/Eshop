using Contracts.Repository.ClientManagement;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ClientManagement
{
    public class ClientRepository : IClientRepository
    {
        private readonly RepositoryContext _context;
        public ClientRepository(RepositoryContext context)
        {
            _context = context;
        }
        public IEnumerable<Client> GetAll()
        {
            return _context.Clients
                .Include(c => c.Addresses)
                .Include(c => c.Sales)
                .ToList();
        }
        public Client GetById(long id)
        {
            return _context.Clients
                .Include(c => c.Addresses)
                .Include(c => c.Sales)
                .FirstOrDefault(c => c.Id == id);
        }
        public void Create(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }

        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
