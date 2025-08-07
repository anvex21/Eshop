using Contracts.DTOs.Country;
using Contracts.Repository.CountryManagement;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers.CountryManagement;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository countryRepository;
    private readonly ICountryService countryService;

    public CountryController(ICountryRepository countryRepository, ICountryService countryService)
    {
        this.countryRepository = countryRepository;
        this.countryService = countryService;
    }
    /// <summary>
    /// Gets all the countries in the database
    /// </summary>
    /// <returns></returns>

    [HttpGet("GetAllCountries")]
    public IActionResult GetAll()
    {
        List<Country> countries = countryRepository.GetAll().ToList();
        if (!countries.Any())
            return NotFound("No countries found.");
        return Ok(countries);
    }

    /// <summary>
    /// Gets a country by its id and returns information about it
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(long id)
    {
        Country country = countryRepository.GetById(id);
        if (country is null)
            return NotFound("Country not found.");
        return Ok(country);
    }

    /// <summary>
    /// Adds a country
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("AddCountry")]
    public IActionResult Add(CountryCreateDto dto)
    {
        Country country = countryService.CreateFromDto(dto);
        countryRepository.Create(country);
        return Ok(country);
    }

    /// <summary>
    /// Updates a certain country using the UpdateDto
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>

    [HttpPut("UpdateCountry/{id}")]
    public IActionResult Update(long id, CountryUpdateDto dto)
    {
        Country country = countryRepository.GetById(id);
        if (country is null)
            return NotFound("Country not found.");

        country.IsoName = dto.IsoName;
        country.Iso2 = dto.Iso2;
        country.Iso3 = dto.Iso3;
        country.PhoneCode = dto.PhoneCode;

        countryRepository.Update(country);
        return Ok(country);
    }

    /// <summary>
    /// Deletes a country from the database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpDelete("DeleteCountry/{id}")]
    public IActionResult Delete(long id)
    {
        Country country = countryRepository.GetById(id);
        if (country is null)
            return NotFound("Country not found.");

        countryRepository.Delete(country);
        return Ok($"Country with ID {id} has been deleted.");
    }

    /// <summary>
    /// Searches for a country based on a passed keyword, returns all the available information for it.
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    [HttpGet("SearchForACountry")]
    public IActionResult Search(string keyword) {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest("Keyword cannot be empty");
        }
        string finalKeyword = keyword.Trim().ToLower();
        IEnumerable<Country> results = countryRepository.GetAll()
            .Where(c =>
            (c.IsoName != null && c.IsoName.ToLowerInvariant().Contains(finalKeyword)) ||
            (c.Iso2 != null && c.Iso2.ToLowerInvariant().Contains(finalKeyword)) ||
            (c.Iso3 != null && c.Iso3.ToLowerInvariant().Contains(finalKeyword)))
        .ToList();
        if (!results.Any())
        {
            return NotFound("No country found with this keyword");
        }
        return Ok(results);
    }

    /// <summary>
    /// Gets all the Iso2 codes in the database
    /// </summary>
    /// <returns></returns>

    [HttpGet("GetAllIso2Codes")]
    public IActionResult GetAllIso2Codes() {
        var iso2Codes = countryRepository.GetAll().Select(c => new {c.Iso2}).ToList();
        if (!iso2Codes.Any())
        {
            return NotFound("Iso2 codes not found.");
        }
        return Ok(iso2Codes);
    }
}

