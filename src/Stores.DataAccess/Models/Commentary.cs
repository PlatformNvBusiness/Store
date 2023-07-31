namespace Stores.DataAccess.Models;

/// <summary>
/// The commentary entity
/// </summary>
public class Commentary
{

    /// <summary>
    /// The id 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The message of the commentary
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// The navigation property for the item
    /// </summary>
    public Item Item { get; set; }

    /// <summary>
    /// The foreign key for the item entity
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// The navigation property for the commentaries
    /// </summary>
    public List<Commentary> Commentaries { get; set; }

    /// <summary>
    /// The navigation property for the store
    /// </summary>
    public Store Store { get; set; }

    /// <summary>
    /// The foreign key for the store
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// The self referenced key for the commentaries
    /// </summary>
    public int CommentaryTypeId { get; set; }

    /// <summary>
    /// The commentary type navigation property
    /// </summary>
    public CommentaryType CommentaryType { get; set; }
}
