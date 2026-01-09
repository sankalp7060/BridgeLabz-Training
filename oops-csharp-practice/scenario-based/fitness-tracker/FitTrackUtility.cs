using System;

class FitTrackUtility
{
    public void TrackWorkouts()
    {
        Workout[] workouts = new Workout[2];
        workouts[0] = new CardioWorkout(30);
        workouts[1] = new StrengthWorkout(45);

        for (int i = 0; i < workouts.Length; i++)
        {
            workouts[i].Track();
            Console.WriteLine();
        }
    }
}
