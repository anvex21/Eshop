using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Sale
{
    /// <summary>
    /// ID
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
    /// Product Id
    /// </summary>
    [Required]
    public long ProductId { get; set; }

    /// <summary>
    /// Product
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [Required]
    [Range(0.01, double.MaxValue)]
    public double Quantity { get; set; }

    /// <summary>
    /// Order Date
    /// </summary>
    [Required]
    [DataType(DataType.Date)]
    public DateTime OrderDate { get; set; }
}
