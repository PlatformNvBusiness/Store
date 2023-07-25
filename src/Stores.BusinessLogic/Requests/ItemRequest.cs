namespace Stores.BusinessLogic.Requests;

public class ItemRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StoreId { get; set; }
    public int CategoryId { get; set; }
}
