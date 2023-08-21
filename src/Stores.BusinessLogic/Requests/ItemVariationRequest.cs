namespace Stores.BusinessLogic.Requests;

public class ItemVariationRequest
{
    public int ItemId { get; set; }
    public decimal PriceVariation { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
}
