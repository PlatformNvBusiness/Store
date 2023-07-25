namespace Stores.DataAccess.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<ItemVariation> ItemVariations { get; set; }
    public List<Commentary> Commentaries { get; set; }
    public int StoreId { get; set; }
    public Store Store { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
