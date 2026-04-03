class TabNode
{
    public string Url { get; set; }
    public TabNode Next { get; set; }
    public TabNode Prev { get; set; }

    public TabNode(string url)
    {
        Url = url;
    }
}
