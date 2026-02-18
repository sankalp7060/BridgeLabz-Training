using Interfaces;
using Services;

namespace Views
{
    /// <summary>
    /// Bootstraps the application.
    /// </summary>
    public static class AppMain
    {
        public static void Start()
        {
            ICitizenManager manager = new CitizenManager();
            Menu menu = new Menu(manager);
            menu.Show();
        }
    }
}
