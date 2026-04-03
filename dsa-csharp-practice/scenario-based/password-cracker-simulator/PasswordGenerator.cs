using System;
using System.Diagnostics;

public class PasswordGenerator
{
    private bool isFound = false;
    private long attempts = 0;

    private readonly char[] charset =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*".ToCharArray();

    public void StartCracking(string target)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        char[] buffer = new char[target.Length];

        Backtrack(buffer, 0, target);

        watch.Stop();

        Console.WriteLine("\n===============================");
        Console.WriteLine("Attempts: " + attempts);
        Console.WriteLine("Time Taken: " + watch.ElapsedMilliseconds + " ms");
        Console.WriteLine("===============================");
    }

    private void Backtrack(char[] buffer, int index, string target)
    {
        if (isFound)
            return;

        string known = "sankalp@";

        for (int i = 0; i < known.Length; i++)
            buffer[i] = known[i];

        if (index < known.Length)
            index = known.Length;

        if (index == buffer.Length)
        {
            attempts++;

            string guess = new string(buffer);

            if (guess.Equals(target))
            {
                isFound = true;
                Console.WriteLine("\nPASSWORD FOUND: " + guess);
            }
            return;
        }

        for (int i = 0; i < 10; i++)
        {
            buffer[index] = (char)('0' + i);
            Backtrack(buffer, index + 1, target);

            if (isFound)
                return;
        }
    }
}
