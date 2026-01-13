public class CinemaMain
{
    public static void Start()
    {
        MovieUtility manager = new MovieUtility(10);
        MovieMenu menu = new MovieMenu(manager);
        menu.ShowMenu();
    }
}
