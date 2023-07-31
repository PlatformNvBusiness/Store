namespace Stores.BusinessLogic.Exceptions
{
    /// <summary>
    /// <inheritdoc/> And can be thrown if the object already exist 
    /// </summary>
    public class ExistException : Exception
    {

        /// <summary>
        /// Initializes a new instance of <see cref="ExistException"/>
        /// </summary>
        /// <param name="message">The message</param>
        public ExistException(string message) : base(message) { }   
    }
}
