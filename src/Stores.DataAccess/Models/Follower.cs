namespace Stores.DataAccess.Models
{
    /// <summary>
    /// The follower entity
    /// </summary>
    public class Follower
    {

        /// <summary>
        /// The id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The user id 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The navigation property for the stores
        /// </summary>
        public List<Store> Stores { get; set; }
    }
}
