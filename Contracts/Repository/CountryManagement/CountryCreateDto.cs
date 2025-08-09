using System.ComponentModel.DataAnnotations;

namespace Contracts.DTOs.Country;
public class CountryCreateDto
{
    /// <summary>
    /// IsoName
    /// </summary>
    [Required]
    [StringLength(50)]
    public string IsoName { get; set; }
    /// <summary>
    /// Iso2
    /// </summary>
    [Required]
    [StringLength(2, MinimumLength = 2)]
    public string Iso2 { get; set; }
    /// <summary>
    /// Iso3
    /// </summary>
    [StringLength(3, MinimumLength = 3)]
    public string Iso3 { get; set; }
    /// <summary>
    /// Phone code
    /// </summary>
    [Required]
    [Phone]
    public string PhoneCode { get; set; }
}