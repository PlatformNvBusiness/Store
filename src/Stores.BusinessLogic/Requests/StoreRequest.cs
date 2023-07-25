using Stores.DataAccess.Models;

namespace Stores.BusinessLogic.Requests
{
    public class StoreRequest
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public float? StoreRating { get; set; }
        public int CategoryId { get; set; }
    }
}
