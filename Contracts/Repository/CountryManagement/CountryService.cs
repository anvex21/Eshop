using Contracts.DTOs.Country;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.CountryManagement
{
    public class CountryService : ICountryService
    {
        public Country CreateFromDto(CountryCreateDto dto)
        {
            return new Country
            {
                IsoName = dto.IsoName,
                Iso2 = dto.Iso2,
                Iso3 = dto.Iso3,
                PhoneCode = dto.PhoneCode
            };
        }

        public Country UpdateFromDto(Country country, CountryUpdateDto dto)
        {
            country.IsoName = dto.IsoName;
            country.Iso2 = dto.Iso2;
            country.Iso3 = dto.Iso3;
            country.PhoneCode = dto.PhoneCode;
            return country;
        }
    }
}
