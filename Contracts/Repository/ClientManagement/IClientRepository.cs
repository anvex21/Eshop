using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.ClientManagement
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();
        Client GetById(long id);
        void Create(Client client);
        void Update(Client client);
        void Delete(Client client);
        void Save();
    }
}
