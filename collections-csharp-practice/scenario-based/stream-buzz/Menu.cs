using System;
using System.Collections.Generic;

sealed class Menu
{
    public void Show()
    {
        IEngagementService service = new EngagementService();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");

            Console.WriteLine("\nEnter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterCreatorUI(service);
                    break;

                case 2:
                    ShowTopPostsUI(service);
                    break;

                case 3:
                    ShowAverageUI(service);
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    // UI Method - Register Creator
    static void RegisterCreatorUI(IEngagementService service)
    {
        Console.WriteLine("Enter Creator Name:");
        string name = Console.ReadLine();

        double[] likes = new double[4];

        Console.WriteLine("Enter weekly likes (Week 1 to 4):");

        for (int i = 0; i < 4; i++)
        {
            likes[i] = Convert.ToDouble(Console.ReadLine());
        }

        CreatorStats creator = new CreatorStats { CreatorName = name, WeeklyLikes = likes };

        service.RegisterCreator(creator);

        Console.WriteLine("Creator registered successfully");
    }

    // UI Method - Show Top Posts
    static void ShowTopPostsUI(IEngagementService service)
    {
        Console.WriteLine("Enter like threshold:");
        double threshold = Convert.ToDouble(Console.ReadLine());

        Dictionary<string, int> result = service.GetTopPostCounts(
            CreatorStats.EngagementBoard,
            threshold
        );

        if (result.Count == 0)
        {
            Console.WriteLine("No top-performing posts this week");
            return;
        }

        foreach (KeyValuePair<string, int> item in result)
        {
            Console.WriteLine(item.Key + " - " + item.Value);
        }
    }

    // UI Method - Show Average
    static void ShowAverageUI(IEngagementService service)
    {
        double avg = service.CalculateAverageLikes();
        Console.WriteLine("Overall average weekly likes: " + avg);
    }
}
