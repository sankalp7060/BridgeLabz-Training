using System;
using System.Collections.Generic;

class TabManagerUtility : ITabManager
{
    private Tab tab;
    private Stack<Tab> closedTab = new Stack<Tab>();
    private HistoryManager historyManager;

    public void Open()
    {
        Console.WriteLine("Enter the page name:- ");
        string page = Console.ReadLine() ?? "";

        tab = new Tab(page);
        historyManager = new HistoryManager(tab);

        Console.WriteLine($"New tab opened: {page}");
    }

    public void Close()
    {
        if (tab != null)
        {
            closedTab.Push(tab);
            tab = null;
            historyManager = null;
            Console.WriteLine("Tab closed.");
        }
    }

    public void RestoreClosedTab()
    {
        if (closedTab.Count > 0)
        {
            tab = closedTab.Pop();
            historyManager = new HistoryManager(tab);
            Console.WriteLine("Tab restored.");
        }
        else
        {
            Console.WriteLine("No closed tabs to restore.");
        }
    }

    public void DisplayCurrentTab()
    {
        if (tab == null)
        {
            Console.WriteLine("No active tab.");
            return;
        }

        Console.WriteLine($"Current page:- {historyManager.GetCurrentPage()}");
    }

    public void Visit()
    {
        if (tab == null)
            return;

        Console.WriteLine("Enter the url:- ");
        string url = Console.ReadLine() ?? "";
        historyManager.Visit(url);
    }

    public void Back()
    {
        if (tab != null)
            historyManager.Back();
    }

    public void Forward()
    {
        if (tab != null)
            historyManager.Forward();
    }

    public string GetCurrentPage()
    {
        return tab == null ? "No Tab" : historyManager.GetCurrentPage();
    }
}
