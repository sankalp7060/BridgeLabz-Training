namespace Views
{
    /// <summary>
    /// Application bootstrapper.
    /// Responsible for starting UI.
    /// </summary>
    public static class AppMain
    {
        public static void Start()
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
