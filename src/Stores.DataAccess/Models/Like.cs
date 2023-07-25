namespace Stores.DataAccess.Models;

public class Like
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; }
}