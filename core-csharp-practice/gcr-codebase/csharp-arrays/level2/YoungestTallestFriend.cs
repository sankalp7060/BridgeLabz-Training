using System;

class YoungestTallestFriend{
    //Main()
    static void Main(){
        string[] names = { "Amar", "Akbar", "Anthony" }; //Name of the three friends is stored in name array
        int[] age = new int[3]; // Age of the three friends is stored in the age array
        double[] height = new double[3]; // Height of the three friends is stored in the height array

        // User given age and height for 3 friends
        for (int i = 0; i < 3; i++){
            Console.WriteLine($"Enter details for {names[i]}:");

            Console.Write("Age: ");
            age[i] = int.Parse(Console.ReadLine());

            Console.Write("Height (in cm): ");
            height[i] = double.Parse(Console.ReadLine());
        }

        // Variable to store youngest friend age
        int youngest = 0;

        // Analyze the youngest friend
        for (int i = 1; i < 3; i++){
            if (age[i] < age[youngest])
                youngest = i;
        }

        // Variable to store tallest friend height
        int tallest = 0;

        // Analyze the tallest friend
        for (int i = 1; i < 3; i++){
            if (height[i] > height[tallest])
                tallest = i;
        }

        Console.WriteLine($"\nYoungest Friend: {names[youngest]} with age {age[youngest]}");
        Console.WriteLine($"Tallest Friend: {names[tallest]} with height {height[tallest]} cm");
    }
}
