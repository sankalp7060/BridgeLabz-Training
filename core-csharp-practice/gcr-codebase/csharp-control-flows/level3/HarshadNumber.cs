using System;

/* A Harshad number (or Niven number) is a positive integer
   that is perfectly divisible by the sum of its own digits
*/

class HarshadNumber{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number:- ");
        int number = int.Parse(Console.ReadLine()); //User given value
        int temp = number;
        int sum = 0;

        //Calulcate the sum of all the digits of the number
        while (temp != 0){
            sum += temp % 10;
            temp = temp / 10;
        }

        //If the the number modulo sum is equal to 0 then it is harshad number otherwise not
        if (number % sum == 0)
            Console.WriteLine("Harshad Number");
        else
            Console.WriteLine("Not a Harshad Number");
    }
}
