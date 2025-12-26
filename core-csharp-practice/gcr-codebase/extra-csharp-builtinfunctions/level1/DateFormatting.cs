using System;

class DateFormatting{
    static void Main(){
        // Get current date
        DateTime today = DateTime.Now;

        // Display date in different formats
        Console.WriteLine("dd/MM/yyyy : " + today.ToString("dd/MM/yyyy"));
        Console.WriteLine("yyyy-MM-dd : " + today.ToString("yyyy-MM-dd"));
        Console.WriteLine("EEE, MMM dd, yyyy : " + today.ToString("ddd, MMM dd, yyyy"));
    }
}
