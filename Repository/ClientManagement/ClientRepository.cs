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
        // Gets all clients
        public IEnumerable<Client> GetAll()
        {
            return _context.Clients
                .Include(c => c.Addresses)
                .Include(c => c.Sales)
                .ToList();
        }
        // Gets a client by its id
        public Client GetById(long id)
        {
            return _context.Clients
                .Include(c => c.Addresses)
                .Include(c => c.Sales)
                .FirstOrDefault(c => c.Id == id);
        }
        // Creates a client
        public void Create(Client client)
        {
            _context.Clients.Add(client);
        }

        // Updates a client

        public void Update(Client client)
        {
            _context.Clients.Update(client);
        }

        // Deletes a client

        public void Delete(Client client)
        {
            _context.Clients.Remove(client);
        }

        // Saves changes

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
