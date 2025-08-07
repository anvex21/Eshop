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

        [HttpGet("GetAllAddresses")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("GetById/{id:long}")]
        public IActionResult GetById(long id)
        {
            AddressDto result = _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("AddAddress")]
        public IActionResult Create([FromBody] AddressDto dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpPut("UpdateAddress/{id}")]
        public IActionResult Update(long id, [FromBody] AddressDto dto)
        {
            AddressDto existingAddress = _service.GetById(id);

            if (existingAddress == null)
                return NotFound($"Address with id {id} not found.");

            _service.Update(dto);
            return Ok();
        }

        [HttpDelete("DeleteAddress/{id:long}")]
        public IActionResult Delete(long id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("GetByCountryId/{countryId:long}")]
        public IActionResult GetByCountryId(long countryId)
        {
            return Ok(_service.GetByCountryId(countryId));
        }

        [HttpGet("GetByClientId/{clientId:long}")]
        public IActionResult GetByClientId(long clientId)
        {
            return Ok(_service.GetByClientId(clientId));
        }
    }
}
