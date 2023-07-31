namespace Stores.BusinessLogic.Requests;

/// <summary>
/// The category request
/// </summary>
public class CategoryRequest
{

    /// <summary>
    /// The name of the category
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The catetory type id
    /// </summary>
    public int CategoryTypeId { get; set; }
}
