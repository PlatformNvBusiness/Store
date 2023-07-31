namespace Stores.DataAccess.Models;

/// <summary>
/// The frequently asked questions entity
/// </summary>
public class Faq
{

    /// <summary>
    /// The id 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The question 
    /// </summary>
    public string Question { get; set; }

    /// <summary>
    /// The response of the question
    /// </summary>
    public string Response { get; set; }

    /// <summary>
    /// foreign key of the store entity
    /// </summary>
    public int StoreId { get; set; }

    /// <summary>
    /// The navigation property for the store
    /// </summary>
    public Store Store { get; set; }
}
