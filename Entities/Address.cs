using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Address
{
    /// <summary>
    /// Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Client Id
    /// </summary>
    [Required]
    public long ClientId { get; set; }

    /// <summary>
    /// Client
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Country Id
    /// </summary>
    [Required]
    public long CountryId { get; set; }

    /// <summary>
    /// Country
    /// </summary>
    public Country Country { get; set; }

    /// <summary>
    /// City
    /// </summary>
    [Required]
    [StringLength(50)]
    public string City { get; set; }

    /// <summary>
    /// Street
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Street { get; set; }

    /// <summary>
    /// Number
    /// </summary>
    [Required]
    [StringLength(20)]
    public string Number { get; set; }

    /// <summary>
    /// Is Main
    /// </summary>
    public bool IsMain { get; set; }
}