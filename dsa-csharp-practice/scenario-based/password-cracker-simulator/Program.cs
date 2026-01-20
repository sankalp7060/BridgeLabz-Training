using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Password To Crack: ");
        string password = Console.ReadLine();

        IPasswordCracker cracker = new PasswordCrackerUtility();

        cracker.CrackPassword(password);

        Console.ReadLine();
    }
}
