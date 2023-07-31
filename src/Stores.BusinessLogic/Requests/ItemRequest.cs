namespace Stores.BusinessLogic.Requests;

/// <summary>
/// The item request
/// </summary>
public class ItemRequest
{

    /// <summary>
    /// The name of item 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The store id
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// The category id
    /// </summary>
    public int CategoryId { get; set; }
}
