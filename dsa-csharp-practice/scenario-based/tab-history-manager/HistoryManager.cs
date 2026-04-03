class HistoryManager
{
    private Tab tab;

    public HistoryManager(Tab tab)
    {
        this.tab = tab;
    }

    public void Visit(string url)
    {
        TabNode node = new TabNode(url);
        tab.Current.Next = node;
        node.Prev = tab.Current;
        tab.Current = node;
    }

    public void Back()
    {
        if (tab.Current.Prev != null)
            tab.Current = tab.Current.Prev;
    }

    public void Forward()
    {
        if (tab.Current.Next != null)
            tab.Current = tab.Current.Next;
    }

    public string GetCurrentPage()
    {
        return tab.Current.Url;
    }
}
