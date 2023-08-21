namespace Stores.BusinessLogic.DTO_s;

public class ItemVariationDto
{
    public int Id { get; set; }
    public ItemDto Item { get; set; }
    public int ItemId { get; set; }
    public decimal PriceVariation { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
