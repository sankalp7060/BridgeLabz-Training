using System;

public class StrengthWorkout : Workout
{
    public StrengthWorkout(int duration)
        : base(duration) { }

    public override void Track()
    {
        Console.WriteLine($"Strength workout tracked for {Duration} minutes.");
        Console.WriteLine($"Calories burned: {Duration * 6}");
    }
}
