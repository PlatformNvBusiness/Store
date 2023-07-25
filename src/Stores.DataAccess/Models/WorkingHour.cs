namespace Stores.DataAccess.Models;

public class WorkingHour
{
    public int Id { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; }
}
