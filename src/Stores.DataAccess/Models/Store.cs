namespace Stores.DataAccess.Models;

/// <summary>
/// The store
/// </summary>
public class Store
{

    /// <summary>
    /// The id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the store
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The user id of the owner of the store
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// The description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The first address Line
    /// </summary>
    public string AddressLineFirst { get; set; }

    /// <summary>
    /// The second address line
    /// </summary>
    public string? AddreesLineSecond { get; set; }

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
    /// The creation date of the store
    /// </summary>
    public DateTimeOffset CreationDate { get; set; }

    /// <summary>
    /// The date of the last update of the store
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// The navigation property for the items
    /// </summary>
    public List<Item>? Items { get; set; }
    /// <summary>
    /// The navigation property for the frequently asked questions
    /// </summary>
    public List<Faq>? Faqs { get; set; }

    /// <summary>
    /// The navigation property for the followers
    /// </summary>
    public List<Follower>? Followers { get; set; }

    /// <summary>
    /// The navigation property for the likes
    /// </summary>
    public List<Like>? Likes { get; set; }

    /// <summary>
    /// The navigation property for the working hours
    /// </summary>
    public List<WorkingHour> WorkingHours { get; set; }

    /// <summary>
    /// The policy of the store
    /// </summary>
    public Policy? Policy { get; set; }

    /// <summary>
    /// The foreign for the category
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// The navigation property for the category
    /// </summary>
    public Category Category { get; set; }

    /// <summary>
    /// The store rating
    /// </summary>
    public float? StoreRating { get; set; }
}
