using System;

class Remove_Duplicates{
    // Main
    public static void Main(string[] args){
        Console.WriteLine("Enter the length of an array:- ");
        int len = int.Parse(Console.ReadLine()); // length input
        int[] array = new int[len];
        for (int i = 0; i < len; i++) array[i] = int.Parse(Console.ReadLine()); // Input elements
        int ans = removeDuplicates(array);
        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }

    // function which returns the length of array after removing the duplicate elements
    public static int removeDuplicates(int[] array){
        int finalLen = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[finalLen] != array[i])
            {
                finalLen++;
                array[finalLen] = array[i];
            }
        }
        return finalLen + 1;
    }
}
