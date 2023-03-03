namespace DTO;

public class PageDTO<T>
{
    public T Data { get; set; }
    public int Index { get; set; }
    public int Count { get; set; }
    public int TotalCount { get; set; }
}