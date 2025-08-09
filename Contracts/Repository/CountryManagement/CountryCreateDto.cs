namespace Contracts.DTOs.Country;
public class CountryCreateDto
{
    /// <summary>
    /// IsoName
    /// </summary>
    public string IsoName { get; set; }
    /// <summary>
    /// Iso2
    /// </summary>
    public string Iso2 { get; set; }
    /// <summary>
    /// Iso3
    /// </summary>
    public string Iso3 { get; set; }
    /// <summary>
    /// Phone code
    /// </summary>
    public string PhoneCode { get; set; }
}