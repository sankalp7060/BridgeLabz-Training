using System;

public class CardioWorkout : Workout
{
    public CardioWorkout(int duration)
        : base(duration) { }

    public override void Track()
    {
        Console.WriteLine($"Cardio workout tracked for {Duration} minutes.");
        Console.WriteLine($"Calories burned: {Duration * 8}");
    }
}
