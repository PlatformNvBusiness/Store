namespace Stores.DataAccess.Models;

/// <summary>
/// The category entity
/// </summary>
public class Category
{
    /// <summary>
    /// The id 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the category
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description of the category
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The foreign key for the category type
    /// </summary>
    public int CategoryTypeId { get; set; }

    /// <summary>
    /// The foreign key object for the category type
    /// </summary>
    public CategoryType CategoryType { get; set; }

    /// <summary>
    /// The navigation property for the store
    /// </summary>
    public List<Store> Stores { get; set; }

    /// <summary>
    /// The navigation property for the items
    /// </summary>
    public List<Item> Items { get; set; }
}
