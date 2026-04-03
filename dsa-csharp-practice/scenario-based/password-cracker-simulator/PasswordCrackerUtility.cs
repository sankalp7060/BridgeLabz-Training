using System;

public class PasswordCrackerUtility : IPasswordCracker
{
    private PasswordGenerator generator;

    public PasswordCrackerUtility()
    {
        generator = new PasswordGenerator();
    }

    public void CrackPassword(string targetPassword)
    {
        Console.WriteLine("\nCracking Started...");
        generator.StartCracking(targetPassword);
    }
}
