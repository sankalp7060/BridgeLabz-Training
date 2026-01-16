public class BookNode
{
    public Book Data;
    public BookNode Next;

    public BookNode(Book data)
    {
        Data = data;
        Next = null;
    }
}
