using System;

class Program
{
    static void Main()
    {
        UserProfile user = new UserProfile("Alex", 25, 70);
        Console.WriteLine(user);

        FitTrackUtility utility = new FitTrackUtility();
        utility.TrackWorkouts();
    }
}
