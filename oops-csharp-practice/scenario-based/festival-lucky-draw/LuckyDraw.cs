using System;

namespace FestivalLuckyDraw
{
    class LuckyDraw
    {
        public void StartDraw()
        {
            while (true)
            {
                Console.Write("Enter lucky draw number (or type exit): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Lucky draw ended. Happy Diwali! 🎉");
                    break;
                }

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    continue; // skip invalid input
                }

                Visitor visitor = new Visitor();
                visitor.DrawNumber = number;

                if (visitor.DrawNumber % 3 == 0 && visitor.DrawNumber % 5 == 0)
                {
                    Console.WriteLine("🎁 Congratulations! You won a gift!");
                }
                else
                {
                    Console.WriteLine("Better luck next time!");
                }

                Console.WriteLine();
            }
        }
    }
}
