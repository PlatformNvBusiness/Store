namespace Stores.DataAccess.Models;

/// <summary>
/// The commentary type 
/// </summary>
public class CommentaryType
{
    /// <summary>
    /// The id of the commentary type
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the commentary type
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description of the commentary type
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The navigation property for the commentaries
    /// </summary>
    public List<Commentary> Commentaries { get; set; }
}
