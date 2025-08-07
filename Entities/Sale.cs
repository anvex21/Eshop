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
    public long ClientId { get; set; }

    /// <summary>
    /// Client
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Product Id
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// Product
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    public double Quantity { get; set; }

    /// <summary>
    /// Order Date
    /// </summary>
    public DateTime OrderDate { get; set; }
}
