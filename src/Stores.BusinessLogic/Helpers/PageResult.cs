namespace Stores.BusinessLogic.Helpers;

public class PageResult<E> where E : class
{
    public int NumberPage { get; set; }
    public int Size { get; set; }
    public int TotalNumberPage { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public List<E>? Data { get; set; }
}
