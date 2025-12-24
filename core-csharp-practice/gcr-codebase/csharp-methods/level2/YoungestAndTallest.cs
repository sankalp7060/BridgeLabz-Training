using System;

class YoungestAndTallest{
    //Main()
    static void Main(){
        int[] ages = new int[3]; //Array to store ages
        double[] heights = new double[3]; //Array to store heights

        for(int i = 0; i < 3; i++){
            Console.WriteLine("Enter age:- ");
            ages[i] = int.Parse(Console.ReadLine()); //User given age

            Console.WriteLine("Enter height:- ");
            heights[i] = double.Parse(Console.ReadLine()); //User given height
        }

        int youngestIndex = FindYoungest(ages); //Find youngest
        int tallestIndex = FindTallest(heights); //Find tallest

        Console.WriteLine("Youngest person index:- " + youngestIndex);
        Console.WriteLine("Tallest person index:- " + tallestIndex);
    }

    //Method to find youngest
    static int FindYoungest(int[] ages){
        int minIndex = 0;
        for(int i = 1; i < ages.Length; i++){
            if(ages[i] < ages[minIndex])
                minIndex = i;
        }
        return minIndex;
    }

    //Method to find tallest
    static int FindTallest(double[] heights){
        int maxIndex = 0;
        for(int i = 1; i < heights.Length; i++){
            if(heights[i] > heights[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }
}
