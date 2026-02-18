using System;

namespace TechVille.OOPS.Views
{
    // Responsible for UI interaction
    public class ConsoleView
    {
        public void ShowMenu()
        {
            Console.WriteLine("\nSelect Service:");
            Console.WriteLine("1. Healthcare");
            Console.WriteLine("2. Education");
            Console.WriteLine("3. Emergency");
        }
    }
}
