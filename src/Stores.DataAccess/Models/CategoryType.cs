namespace Stores.DataAccess.Models;

/// <summary>
/// The category type entity
/// </summary>
public class CategoryType
{
    /// <summary>
    /// The id 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the category type
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The navigation property for the categories
    /// </summary>
    public List<Category> Categories { get; set; }
}
