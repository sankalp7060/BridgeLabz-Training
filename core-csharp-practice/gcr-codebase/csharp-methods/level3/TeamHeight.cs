using System;

class TeamHeight{
    //Main()
    static void Main()
    {
        int[] heights = GenerateRandomHeights(); //Store heights of players

        int sumOfHeights = FindSum(heights); //Find sum
        int shortestHeight = FindShortest(heights); //Find shortest
        int tallestHeight = FindTallest(heights); //Find tallest
        double meanHeight = FindMean(sumOfHeights, heights.Length); //Find mean

        Console.WriteLine("Shortest Height : " + shortestHeight + " cms");
        Console.WriteLine("Tallest Height  : " + tallestHeight + " cms");
        Console.WriteLine("Mean Height     : " + meanHeight + " cms");
    }

    //Generate random heights between 150 to 250
    static int[] GenerateRandomHeights()
    {
        int[] heights = new int[11];
        Random random = new Random();

        for(int i = 0; i < heights.Length; i++)
        {
            heights[i] = random.Next(150, 251);
        }

        return heights;
    }

    //Find sum of heights
    static int FindSum(int[] heights)
    {
        int sum = 0;

        foreach(int height in heights)
        {
            sum += height;
        }

        return sum;
    }

    //Find mean height
    static double FindMean(int sum, int count){
        return (double)sum / count;
    }

    //Find shortest height
    static int FindShortest(int[] heights){
        int minHeight = heights[0];

        foreach(int height in heights)
        {
            minHeight = Math.Min(minHeight, height);
        }

        return minHeight;
    }

    //Find tallest height
    static int FindTallest(int[] heights){
        int maxHeight = heights[0];

        foreach(int height in heights)
        {
            maxHeight = Math.Max(maxHeight, height);
        }

        return maxHeight;
    }
}
