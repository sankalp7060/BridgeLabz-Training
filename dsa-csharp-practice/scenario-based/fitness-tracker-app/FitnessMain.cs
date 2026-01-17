using System;

public class FitnessMain
{
    public static void Start()
    {
        User[] users = new User[7];

        users[0] = new User(1, "Aman", 8500);
        users[1] = new User(2, "Neha", 12000);
        users[2] = new User(3, "Rahul", 7600);
        users[3] = new User(4, "Pooja", 15000);
        users[4] = new User(5, "Karan", 9800);
        users[5] = new User(6, "Simran", 11000);
        users[6] = new User(7, "Arjun", 6500);

        UserUtility rankingService = new UserUtility();

        Console.WriteLine("----- BEFORE RANKING -----");
        rankingService.Display(users);

        // Real-time step update
        Console.WriteLine("\n>> Real-time step sync update for Rahul...");
        users[2].Steps = 14000;

        rankingService.RankUsers(users);

        Console.WriteLine("\n----- UPDATED DAILY LEADERBOARD -----");
        rankingService.Display(users);

        Console.ReadLine();
    }
}
