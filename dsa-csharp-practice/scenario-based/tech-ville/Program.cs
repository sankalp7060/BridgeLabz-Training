using TechVille.DSA.Views;

namespace TechVille.DSA
{
    class Program
    {
        static void Main()
        {
            // Program only starts UI
            MainMenuView view = new MainMenuView();
            view.Start();
        }
    }
}
