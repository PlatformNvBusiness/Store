namespace Stores.DataAccess.Models;

public class Commentary
{
    public int Id { get; set; }
    public string Message { get; set; }
    public Item Item { get; set; }
    public int ItemId { get; set; }
    public List<Commentary> Commentaries { get; set; } 
    public Store Store { get; set; }
    public int StoreId { get; set; }
    public int CommentaryTypeId { get; set; }
    public CommentaryType CommentaryType { get; set; }
}