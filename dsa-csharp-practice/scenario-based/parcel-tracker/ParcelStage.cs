public class ParcelStage
{
    public string StageName { get; set; }
    public ParcelStage Next { get; set; }

    public ParcelStage(string stage)
    {
        StageName = stage;
        Next = null;
    }
}
