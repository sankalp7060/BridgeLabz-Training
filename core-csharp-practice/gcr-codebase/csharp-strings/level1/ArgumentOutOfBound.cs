using System;

class ArgumentOutOfBound{
    //Main()
    static void Main(){
        try{
            string s = "Hello";
            //Invalid substring
            string sub = s.Substring(4, 0); //valid
            string sub2 = s.Substring(4, 10); //invalid
            Console.WriteLine(sub2);
        }
        catch(ArgumentOutOfRangeException ex){
            Console.WriteLine("Caught ArgumentOutOfRangeException: " + ex.Message);
        }
    }
}
