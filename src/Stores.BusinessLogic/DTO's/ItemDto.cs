namespace Stores.BusinessLogic.DTO_s;

/// <summary>
/// The item data transfert object
/// </summary>
public class ItemDto
{

    /// <summary>
    /// The id of the item
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the item
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

}
