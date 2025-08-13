using Contracts.Repository.AddressManagement;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers.AddressManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all the addresses
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAddresses")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// Gets an address by an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(long id)
        {
            AddressDto result = _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Adds a new address
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost("AddAddress")]
        public IActionResult Create(AddressDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Create(dto);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Updates an existing address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("UpdateAddress/{id}")]
        public IActionResult Update(long id, AddressDto dto)
        {
            if(ModelState.IsValid)
            {
                AddressDto existingAddress = _service.GetById(id);

                if (existingAddress is null)
                    return NotFound($"Address with id {id} not found.");

                _service.Update(dto);
                return Ok();

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Deletes an address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("DeleteAddress/{id}")]
        public IActionResult Delete(long id)
        {
            _service.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Gets an address by a country id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>

        [HttpGet("GetByCountryId/{countryId}")]
        public IActionResult GetByCountryId(long countryId)
        {
            return Ok(_service.GetByCountryId(countryId));
        }

        /// <summary>
        /// Gets an address by a client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>

        [HttpGet("GetByClientId/{clientId}")]
        public IActionResult GetByClientId(long clientId)
        {
            return Ok(_service.GetByClientId(clientId));
        }

        [HttpGet("GetAllMainAddresses/{clientId}")]
        public IActionResult GetMainAddresses(long clientId)
        {
            List<AddressDto> mainAddresses = _service.GetByClientId(clientId)
                .Where(a => a.IsMain == true)
                .ToList();
            if (!mainAddresses.Any())
            {
                return NotFound("No main addresses found.");
            }
            return Ok(mainAddresses);
           
        }
    }
}
