namespace Stores.DataAccess.Models;

public class CategoryType
{
    public int Id { get; set; }
    public string Name { get;set; } 
    public List<Category> Categories { get; set; }
}
