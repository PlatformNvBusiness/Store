namespace Stores.DataAccess.Models;

/// <summary>
/// The item entity of the store
/// </summary>
public class Item
{

    /// <summary>
    /// The id 
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
    /// The price of the item
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The navigation property for the item variations
    /// </summary>
    public List<ItemVariation> ItemVariations { get; set; }

    /// <summary>
    /// The commentaries navigation property
    /// </summary>
    public List<Commentary> Commentaries { get; set; }

    /// <summary>
    /// The foreign key of the store 
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// The navigation property for the store
    /// </summary>
    public Store Store { get; set; }

    /// <summary>
    /// The foreign key for the category id
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// The navigation property for the category
    /// </summary>
    public Category Category { get; set; }
}
