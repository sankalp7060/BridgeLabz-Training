using DataAccess;
using Interfaces;
using Services;

namespace Views
{
    /// <summary>
    /// Application entry point for Collections version.
    /// Sets up dependencies and launches UI.
    /// </summary>
    public static class AppMain
    {
        public static void Start()
        {
            IPatientRepository repo = new PatientRepository();
            IPatientService service = new PatientService(repo);

            Menu menu = new Menu(service);
            menu.Show();
        }
    }
}
