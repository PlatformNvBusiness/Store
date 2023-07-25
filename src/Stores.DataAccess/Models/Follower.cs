namespace Stores.DataAccess.Models
{
    public class Follower
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Store> Stores { get; set; }
    }
}
