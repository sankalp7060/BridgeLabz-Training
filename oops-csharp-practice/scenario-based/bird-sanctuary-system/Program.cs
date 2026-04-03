using System;

class Program
{
    static void Main()
    {
        Bird[] birds = new Bird[5];

        birds[0] = new Eagle("Mighty");
        birds[1] = new Sparrow("Chirpy");
        birds[2] = new Duck("Daffy");
        birds[3] = new Penguin("Pingu");
        birds[4] = new Seagull("Sky");

        Console.WriteLine("=== EcoWing Bird Sanctuary ===\n");

        for (int i = 0; i < birds.Length; i++)
        {
            birds[i].DisplayDetails();

            if (birds[i] is IFlyable)
                ((IFlyable)birds[i]).Fly();

            if (birds[i] is ISwimmable)
                ((ISwimmable)birds[i]).Swim();

            Console.WriteLine();
        }
    }
}
