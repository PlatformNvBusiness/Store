namespace Stores.DataAccess.Models;

public class Policy
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; }
}
