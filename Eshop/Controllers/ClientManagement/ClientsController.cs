using Contracts.Repository.ClientManagement;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers.ClientManagement
{
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }
        /// <summary>
        /// Gets all clients
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllClients")]
        public ActionResult<IEnumerable<ClientDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// Gets a client by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetClientById/{id}")]
        public ActionResult<ClientDto> GetById(long id)
        {
            var client = _service.GetById(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        /// <summary>
        /// Adds a client
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost("AddClient")]
        public IActionResult Create(ClientDto dto)
        {
            _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("UpdateClient/{id}")]
        public IActionResult Update(long id,ClientDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            _service.Update(dto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("DeleteClient/{id}")]
        public IActionResult Delete(long id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
