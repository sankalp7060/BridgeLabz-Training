using System;

public abstract class Workout : ITrackable
{
    public int Duration { get; private set; }

    protected Workout(int duration)
    {
        Duration = duration;
    }

    public abstract void Track();
}
