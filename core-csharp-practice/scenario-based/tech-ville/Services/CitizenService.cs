using Interfaces;
using Models;

namespace Services
{
    /// <summary>
    /// Service layer containing business logic.
    ///
    /// CORE TOPICS COVERED:
    /// - Arithmetic operators
    /// - Comparison operators
    /// - If-else conditions
    /// - Switch statement
    /// - Loops (for)
    /// - Ternary operator
    /// </summary>
    public class CitizenService : ICitizenService
    {
        // Stores currently registered citizen (core level: single object)
        private Citizen citizen;

        /// <summary>
        /// Registers citizen and calculates eligibility score.
        /// </summary>
        public void RegisterCitizen(Citizen c)
        {
            // Store citizen
            citizen = c;

            // -------------------------------
            // Eligibility score calculation
            // -------------------------------
            // Formula using arithmetic operators:
            // age weight + income factor + residency factor
            double score = 0;

            score += citizen.Age * 0.5;
            score += citizen.ResidencyYears * 2;

            // Income condition using comparison operator
            if (citizen.Income > 1000000)
                score += 20;
            else if (citizen.Income > 500000)
                score += 10;
            else
                score += 5;

            citizen.EligibilityScore = score;

            // -------------------------------
            // Service package selection
            // using nested if-else
            // -------------------------------
            if (score >= 80)
                citizen.ServicePackage = "Platinum";
            else if (score >= 60)
                citizen.ServicePackage = "Gold";
            else if (score >= 40)
                citizen.ServicePackage = "Silver";
            else
                citizen.ServicePackage = "Basic";

            Console.WriteLine("\nCitizen Registered Successfully!\n");
        }

        /// <summary>
        /// Displays registered citizen information.
        /// </summary>
        public void ShowCitizen()
        {
            if (citizen == null)
            {
                Console.WriteLine("No citizen registered.");
                return;
            }

            Console.WriteLine("\n===== Citizen Information =====");
            Console.WriteLine($"Name: {citizen.Name}");
            Console.WriteLine($"Age: {citizen.Age}");
            Console.WriteLine($"Income: {citizen.Income}");
            Console.WriteLine($"Residency Years: {citizen.ResidencyYears}");
            Console.WriteLine($"Eligibility Score: {citizen.EligibilityScore}");
            Console.WriteLine($"Service Package: {citizen.ServicePackage}");

            // Ternary operator example
            string status = citizen.Age >= 18 ? "Adult" : "Minor";

            Console.WriteLine($"Status: {status}");
        }

        /// <summary>
        /// Demonstrates loop usage by registering
        /// multiple family members in one session.
        /// </summary>
        public void RegisterFamilyMembers()
        {
            Console.Write("Enter number of family members: ");
            int count = int.Parse(Console.ReadLine());

            // FOR loop example
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"\n--- Family Member {i} ---");

                Citizen temp = new Citizen();

                Console.Write("Name: ");
                temp.Name = Console.ReadLine();

                Console.Write("Age: ");
                temp.Age = int.Parse(Console.ReadLine());

                Console.Write("Income: ");
                temp.Income = double.Parse(Console.ReadLine());

                Console.Write("Residency Years: ");
                temp.ResidencyYears = int.Parse(Console.ReadLine());

                // Quick validation using continue
                if (temp.Age <= 0)
                {
                    Console.WriteLine("Invalid age. Skipping...");
                    continue;
                }

                // Register each family member
                RegisterCitizen(temp);
            }
        }
    }
}
