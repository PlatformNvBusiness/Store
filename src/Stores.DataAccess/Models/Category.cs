namespace Stores.DataAccess.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }
        public List<Store> Stores { get; set; }
        public List<Item> Items { get; set; }
    }
}
