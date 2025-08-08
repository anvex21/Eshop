using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.ClientManagement
{
    public interface IClientService
    {
        IEnumerable<ClientDto> GetAll();
        ClientDto GetById(long id);
        void Create(ClientDto dto);
        void Update(ClientDto dto);
        void Delete(long id);
    }
}
