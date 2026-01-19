public class StackNode
{
    public Submission Data;
    public StackNode Next;

    public StackNode(Submission data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomStack
{
    private StackNode top;

    public void Push(Submission s)
    {
        StackNode node = new StackNode(s);
        node.Next = top;
        top = node;
    }

    public Submission Pop()
    {
        if (top == null)
            return null;
        Submission val = top.Data;
        top = top.Next;
        return val;
    }

    public bool IsEmpty() => top == null;
}
