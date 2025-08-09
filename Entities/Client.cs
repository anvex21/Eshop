using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Client
{
    /// <summary>
    /// ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// First Name
    /// </summary>
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    /// <summary>
    /// Last Name
    /// </summary>
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    /// <summary>
    /// Age
    /// </summary>
    [Required]
    [Range(0, 120)]
    public int Age { get; set; }

    /// <summary>
    /// Sex
    /// </summary>
    [Required]
    [StringLength(10)]
    public string Sex { get; set; }

    /// <summary>
    /// Addresses
    /// </summary>
    public List<Address> Addresses { get; set; }

    /// <summary>
    /// Sales
    /// </summary>
    public List<Sale> Sales { get; set; }
}
