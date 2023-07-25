

namespace Stores.DataAccess.Models;

public class ItemVariation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PriceVariation { get; set; }
    
    public decimal TotalPrice
    {
        get => Item.Price + PriceVariation;
    }
    public int ItemId { get; set; }
    public Item Item { get; set; }
}
