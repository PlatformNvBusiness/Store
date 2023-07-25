using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.DataAccess.Models;

public class Store
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
    public List<Item>? Items { get; set; }
    public List<Faq>? Faqs { get; set; }
    public List<Follower>? Followers { get; set; }
    public List<Like>? Likes { get; set; }
    public List<WorkingHour> WorkingHours { get; set; }
    public Policy? Policy { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public float? StoreRating { get; set; } 
    
}
