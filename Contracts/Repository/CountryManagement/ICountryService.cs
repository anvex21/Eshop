using Contracts.DTOs.Country;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.CountryManagement
{
    public interface ICountryService
    {
        Country CreateFromDto(CountryCreateDto dto);
        Country UpdateFromDto(Country country, CountryUpdateDto dto);
    }
}
