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
    public long ClientId { get; set; }

    /// <summary>
    /// Client
    /// </summary>
    public Client Client { get; set; }

    /// <summary>
    /// Country Id
    /// </summary>
    public long CountryId { get; set; }

    /// <summary>
    /// Country
    /// </summary>
    public Country Country { get; set; }

    /// <summary>
    /// City
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Street
    /// </summary>
    public string Street { get; set; }

    /// <summary>
    /// Number
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Is Main
    /// </summary>
    public bool IsMain { get; set; }
}