namespace Stores.BusinessLogic.DTO_s;

/// <summary>
/// The store data transfert object
/// </summary>
public class StoreDto
{
    
    /// <summary>
    /// The id of the store
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the store
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
    /// The first address line
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
    /// The date of creation
    /// </summary>
    public DateTimeOffset CreationDate { get; set; }

    /// <summary>
    /// The date of the last update
    /// </summary>
    public DateTimeOffset UpdateDate { get; set; }

    /// <summary>
    /// The items
    /// </summary>
    public List<ItemDto>? Items { get; set; }

    /// <summary>
    /// The category
    /// </summary>
    public CategoryDto Category { get; set; }

    /// <summary>
    /// The rating of the store
    /// </summary>
    public float? StoreRating { get; set; }
}
