namespace Stores.BusinessLogic.Requests;

/// <summary>
/// The store request
/// </summary>
public class StoreRequest
{

    /// <summary>
    /// The name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The user id of the owner
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// The description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The adress Line first
    /// </summary>
    public string AddressLineFirst { get; set; }

    /// <summary>
    /// The second address line
    /// </summary>
    public string AddressLineSecond { get; set; }

    /// <summary>
    /// The city
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// The region
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// The postal code
    /// </summary>
    public string PostalCode { get; set; }

    /// <summary>
    /// The country
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// The rating of the store
    /// </summary>
    public float? StoreRating { get; set; }

    /// <summary>
    /// The category id
    /// </summary>
    public int CategoryId { get; set; }
}
