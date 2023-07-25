namespace Stores.DataAccess.Models;

public class Faq
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Response { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; }
}
