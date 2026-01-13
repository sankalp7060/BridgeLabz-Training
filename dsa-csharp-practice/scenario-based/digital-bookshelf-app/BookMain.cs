class BookMain
{
    public static void Start()
    {
        BookUtility manager = new BookUtility(100);
        BookMenu menu = new BookMenu(manager);
        menu.ShowMenu();
    }
}
