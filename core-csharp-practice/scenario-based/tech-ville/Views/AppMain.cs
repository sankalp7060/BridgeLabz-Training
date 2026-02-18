using Interfaces;
using Services;

namespace Views
{
    /// <summary>
    /// Application coordinator.
    ///
    /// RESPONSIBILITY:
    /// - Create dependencies
    /// - Start application flow
    /// </summary>
    public static class AppMain
    {
        public static void Start()
        {
            // Manual dependency creation (core level DI)
            ICitizenService service = new CitizenService();

            // Start menu
            Menu menu = new Menu(service);
            menu.Show();
        }
    }
}
