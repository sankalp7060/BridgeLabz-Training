using System;

class FormatExceptionDemo{
    static void Main(){
        try{
            string s = "abc";
            int num = int.Parse(s); //Invalid parsing
        }
        catch(FormatException ex){ //System.FormatException
            Console.WriteLine("Caught FormatException: " + ex.Message);
        }
    }
}
