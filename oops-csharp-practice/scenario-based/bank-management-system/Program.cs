using System;

class Program
{
    static void Main()
    {
        // Database size 10
        AccountDatabase db = new AccountDatabase(10);

        // Start user interface
        UserInterface ui = new UserInterface(db);
        ui.Start();
    }
}
