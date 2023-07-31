namespace Stores.DataAccess.Models;

/// <summary>
/// The working hours of the store
/// </summary>
public class WorkingHour
{
    
    /// <summary>
    /// The id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The start or the begining of the working day
    /// </summary>
    public int Start { get; set; }

    /// <summary>
    /// The end of the working day
    /// </summary>
    public int End { get; set; }

    /// <summary>
    /// The foreign key for the store
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// The navigation property for the store
    /// </summary>
    public Store Store { get; set; }
}
