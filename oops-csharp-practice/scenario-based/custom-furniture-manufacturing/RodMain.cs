using System;

public class RodMain
{
    public static void Execute()
    {
        int[] prices = { 2, 6, 9, 12, 14, 17, 20, 22, 25, 27, 30, 33 };
        WoodenRod rod = new WoodenRod(12, prices);
        RodUtilityImpl utility = new RodUtilityImpl(1);

        while (true)
        {
            RodMenu.ShowMenu();
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    rod.DisplayResult(utility);
                    break;

                case 2:
                    Console.Write("Enter allowed waste (ft): ");
                    int waste = int.Parse(Console.ReadLine());
                    utility.SetWasteConstraint(waste);
                    rod.DisplayResult(utility);
                    break;

                case 3:
                    utility.SuggestBestCut(rod.Length, prices);
                    break;

                case 4:
                    return;
            }
            Console.WriteLine();
        }
    }
}
