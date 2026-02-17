using DataAccess;
using Interfaces;
using Services;

namespace Views
{
    /// <summary>
    /// Application entry coordinator.
    /// Creates dependencies and starts UI.
    /// </summary>
    public static class AppMain
    {
        public static void Start()
        {
            // Dependency creation (Manual DI)
            IPatientRepository repo = new PatientRepository();
            IPatientService service = new PatientService(repo);

            Menu menu = new Menu(service);
            menu.Show();
        }
    }
}
