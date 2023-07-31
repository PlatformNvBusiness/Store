namespace Stores.BusinessLogic.DTO_s;

/// <summary>
/// The category data transfert object
/// </summary>
public class CategoryDto
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
    /// The descritpion
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The category type
    /// </summary>
    public CategoryTypeDto CategoryType { get; set; }
}
