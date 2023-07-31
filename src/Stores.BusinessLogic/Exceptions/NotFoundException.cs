namespace Stores.BusinessLogic.Exceptions;

/// <summary>
/// <inheritdoc/> And Can the thrown if the object does not exist
/// </summary>
public class NotFoundException : Exception
{

    /// <summary>
    /// Initializes a new instance of <see cref="NotFoundException"/>
    /// </summary>
    /// <param name="message">The message</param>
    public NotFoundException(string? message) : base(message)
    {
    }
}
