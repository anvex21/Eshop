using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Product
{
    /// <summary>
    /// ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Required]
    [StringLength(70)]
    public string Name { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Type { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
}
