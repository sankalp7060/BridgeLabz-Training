using System;

class NullReferenceDemo{
    //Main()
    static void Main(){
        try{
            string s = null;
            //Access method on null string
            Console.WriteLine(s.Length);
        }
        catch(NullReferenceException ex){
            Console.WriteLine("Caught NullReferenceException: " + ex.Message);
        }
    }
}
