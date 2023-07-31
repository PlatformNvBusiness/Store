namespace Stores.DataAccess.Models;

/// <summary>
/// The item variation of the item
/// </summary>
public class ItemVariation
{

    /// <summary>
    /// The id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the item variation
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The price variation of the item
    /// </summary>
    public decimal PriceVariation { get; set; }
    
    /// <summary>
    /// The total price
    /// </summary>
    public decimal TotalPrice
    {
        get => Item.Price + PriceVariation;
    }

    /// <summary>
    /// The foreign key of the item entity
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// The item navigation property
    /// </summary>
    public Item Item { get; set; }
}
