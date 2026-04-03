using System;

class IndexOutOfBound{
    //Main()
    static void Main(){
        try{
            string s = "Hello";
            //Access invalid index
            Console.WriteLine(s[10]);
        }
        catch(IndexOutOfRangeException ex){
            Console.WriteLine("Caught IndexOutOfRangeException: " + ex.Message);
        }
    }
}
