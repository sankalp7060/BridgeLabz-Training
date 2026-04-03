using System;

class RodMenu
{
    public void Menu()
    {
        // Menu driven program
        while (true)
        {
            Console.WriteLine("=== Metal Rod Factory ===");
            Console.WriteLine("1. Scenario A (Rod length 8)");
            Console.WriteLine("2. Scenario B (Custom rod length 10)");
            Console.WriteLine("3. Scenario C (Naive revenue visualization)");
            Console.WriteLine("4. Factory Revenue Summary");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            // Fixed array for factory
            RodUtilityImpl utility = new RodUtilityImpl(2);
            int[] pricesA = { 1, 5, 8, 9, 10, 17, 17, 20 };
            int[] pricesB = { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            MetalRod rodA = new MetalRod(8, pricesA);
            MetalRod rodB = new MetalRod(10, pricesB);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Scenario A:");
                    rodA.DisplayRevenueChart(utility);
                    break;

                case 2:
                    Console.WriteLine("Scenario B:");
                    rodB.DisplayRevenueChart(utility);
                    break;

                case 3:
                    Console.WriteLine("Scenario C: Naive Revenue");
                    int naiveRevenue = 0;
                    for (int i = 0; i < rodB.Length; i++)
                        naiveRevenue += pricesB[0];
                    Console.WriteLine("Naive Revenue: " + naiveRevenue);
                    break;

                case 4:
                    utility.AddRod(rodA);
                    utility.AddRod(rodB);
                    Console.WriteLine("Factory Revenue Summary:");
                    utility.ShowAllRevenue();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
            Console.WriteLine();
        }
    }
}
