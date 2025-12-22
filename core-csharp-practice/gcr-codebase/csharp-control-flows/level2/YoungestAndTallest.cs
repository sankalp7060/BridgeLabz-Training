using System;

class YoungestAndTallest{
    //main()
    static void Main(){
        Console.WriteLine("Enter the age of the three friends:- ");
        int ageAmar = int.Parse(Console.ReadLine()); //Amar age
        int ageAkbar = int.Parse(Console.ReadLine()); //Akbar age
        int ageAnthony = int.Parse(Console.ReadLine()); //Anthony age

        int heightAmar = int.Parse(Console.ReadLine()); //Amar's height
        int heightAkbar = int.Parse(Console.ReadLine()); //Akbar's height
        int heightAnthony = int.Parse(Console.ReadLine()); //Anthony's height

        //Conditions to check which friend is youngest and taller than others
        if (ageAmar < ageAkbar && ageAmar < ageAnthony)
            Console.WriteLine("Amar is youngest");
        else if (ageAkbar < ageAmar && ageAkbar < ageAnthony)
            Console.WriteLine("Akbar is youngest");
        else
            Console.WriteLine("Anthony is youngest");

        if (heightAmar > heightAkbar && heightAmar > heightAnthony)
            Console.WriteLine("Amar is tallest");
        else if (heightAkbar > heightAmar && heightAkbar > heightAnthony)
            Console.WriteLine("Akbar is tallest");
        else
            Console.WriteLine("Anthony is tallest");
    }
}
