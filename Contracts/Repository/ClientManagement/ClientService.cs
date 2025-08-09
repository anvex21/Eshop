using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.ClientManagement
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        // Constructor
        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        // Gets all the clients in the databse
        public IEnumerable<ClientDto> GetAll()
        {
            return _repository.GetAll().Select(c => new ClientDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Age = c.Age,
                Sex = c.Sex,
                AddressIds = c.Addresses?.Select(a => a.Id).ToList() ?? new List<long>(),
            });
        }

        // Gets information about hte client by its id

        public ClientDto GetById(long id)
        {
            var client = _repository.GetById(id);
            if (client == null) return null;

            return new ClientDto
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Age = client.Age,
                Sex = client.Sex,
                AddressIds = client.Addresses?.Select(a => a.Id).ToList() ?? new List<long>(),               
            };
        }

        // Adds a new client to the database

        public void Create(ClientDto dto)
        {
            var client = new Client
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                Sex = dto.Sex,
                Addresses = dto.AddressIds?.Select(id => new Address { Id = id }).ToList(),
            };

            _repository.Create(client);
            _repository.Save();
        }

        // Updates an existing client
        public void Update(ClientDto dto)
        {
            var client = _repository.GetById(dto.Id);
            if (client == null) return;

            client.FirstName = dto.FirstName;
            client.LastName = dto.LastName;
            client.Age = dto.Age;
            client.Sex = dto.Sex;
            client.Addresses = dto.AddressIds?.Select(id => new Address { Id = id }).ToList();

            _repository.Update(client);
            _repository.Save();
        }

        // Deletes a client
        public void Delete(long id)
        {
            var client = _repository.GetById(id);
            if (client == null) return;

            _repository.Delete(client);
            _repository.Save();
        }
    }
}
