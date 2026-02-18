using TechVille.Core.Interfaces;
using TechVille.Core.Models;

namespace TechVille.Core.View
{
    public class ConsoleUI
    {
        private readonly ICitizenService _citizenService;

        public ConsoleUI(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public void Start()
        {
            Console.WriteLine("===== TechVille Smart City Registration =====");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Income: ");
            double income = double.Parse(Console.ReadLine());

            Console.Write("Enter Residency Years: ");
            int residency = int.Parse(Console.ReadLine());

            Citizen citizen = new Citizen(name, age, income, residency);

            var result = _citizenService.RegisterCitizen(citizen);

            Console.WriteLine(result.Message);

            if (result.IsSuccessful)
                _citizenService.DisplayCitizen(result.Citizen);
        }
    }
}
