using System;

class ArrayIndexOutOfBound{
    static void Main(){
        try{
            int[] arr = {1,2,3};
            Console.WriteLine(arr[5]); //Invalid index
        }
        catch(IndexOutOfRangeException ex){
            Console.WriteLine("Caught IndexOutOfRangeException: " + ex.Message);
        }
    }
}
