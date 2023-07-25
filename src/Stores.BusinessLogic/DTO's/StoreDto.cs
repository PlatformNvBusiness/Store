using Stores.DataAccess.Models;

namespace Stores.BusinessLogic.DTO_s;

public class StoreDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public List<ItemDto>? Items { get; set; }
    public CategoryDto Category { get; set; }
    public float? StoreRating { get; set; }
}
