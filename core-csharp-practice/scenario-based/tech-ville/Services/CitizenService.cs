using System;
using TechVille.Core.Interfaces;
using TechVille.Core.Models;

namespace TechVille.Core.Services
{
    public class CitizenService : ICitizenService
    {
        private ValidationService validator = new ValidationService();

        public Citizen RegisterCitizen()
        {
            Citizen c = new Citizen();

            Console.Write("Enter Name: ");
            c.Name = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                if (!validator.ValidateAge(age))
                {
                    Console.WriteLine("Invalid age!");
                    continue;
                }

                c.Age = age;
                break;
            }

            Console.Write("Enter Income: ");
            c.Income = Convert.ToDouble(Console.ReadLine());

            Console.Write("Residency Years: ");
            c.ResidencyYears = Convert.ToInt32(Console.ReadLine());

            c.CitizenId = new Random().Next(1000, 9999);

            return c;
        }

        public void DisplayCitizen(Citizen c)
        {
            Console.WriteLine("\n===== Citizen Info =====");
            Console.WriteLine($"ID: {c.CitizenId}");
            Console.WriteLine($"Name: {c.Name}");
            Console.WriteLine($"Age: {c.Age}");
            Console.WriteLine($"Income: {c.Income}");
            Console.WriteLine($"Residency: {c.ResidencyYears}");
            Console.WriteLine($"Score: {c.EligibilityScore}");
            Console.WriteLine($"Package: {c.Package}");
        }
    }
}
