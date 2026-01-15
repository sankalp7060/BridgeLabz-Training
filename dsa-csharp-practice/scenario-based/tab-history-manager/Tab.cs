class Tab
{
    public TabNode Current { get; set; }

    public Tab(string current)
    {
        Current = new TabNode(current);
    }
}
