public class StageNode
{
    public string Stage;
    public StageNode Next;

    public StageNode(string stage)
    {
        Stage = stage;
        Next = null;
    }
}
