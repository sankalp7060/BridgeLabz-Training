using System;

class Movie
{
    public string Title { get; private set; }
    public string Time { get; private set; }

    public Movie(string title, string time)
    {
        Title = title;
        Time = time;
    }
}
