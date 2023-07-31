namespace Stores.DataAccess.Models;

/// <summary>
/// The policy of the store
/// </summary>
public class Policy
{

    /// <summary>
    /// The id 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the policy
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The descrpition
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The foreign key of the store
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// The store navigation property
    /// </summary>
    public Store Store { get; set; }
}
