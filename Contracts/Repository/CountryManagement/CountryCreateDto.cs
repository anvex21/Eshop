namespace Contracts.DTOs.Country;
public class CountryCreateDto
{
    public string IsoName { get; set; }
    public string Iso2 { get; set; }
    public string Iso3 { get; set; }
    public string PhoneCode { get; set; }
}