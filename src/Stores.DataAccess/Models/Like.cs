namespace Stores.DataAccess.Models;

/// <summary>
/// The like of the stores
/// </summary>
public class Like
{

    /// <summary>
    /// The id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The user id
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// The foreign key of the store
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// The navigation property for the store
    /// </summary>
    public Store Store { get; set; }
}
