public class HashNode
{
    public string Key;
    public BookLinkedList Value;
    public HashNode Next;

    public HashNode(string key)
    {
        Key = key;
        Value = new BookLinkedList();
        Next = null;
    }
}
