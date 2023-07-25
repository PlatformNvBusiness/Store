namespace Stores.DataAccess.Models;

public class CommentaryType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Commentary> Commentaries { get; set; }
}
