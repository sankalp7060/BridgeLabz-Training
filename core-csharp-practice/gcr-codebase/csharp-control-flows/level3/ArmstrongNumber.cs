using System;
 
/*Armstrong Number is a number that equals the sum of its own digits,
  each raised to the power of the total number of digits in the number 
*/

class ArmstrongNumber{
    //Main()
    static void Main(){
        Console.WriteLine("Enter the number to e checked for armstrong or not:- ");
        int number = int.Parse(Console.ReadLine()); //User given number 
        int originalNumber = number;
        int sum = 0;
        
        //Check whether a number is armstrong or not using while loop
        while (originalNumber != 0){
            int rem = originalNumber % 10;
            sum += rem * rem * rem;
            originalNumber = originalNumber / 10;
        }

        //Display the output accordingly
        if (sum == number)
            Console.WriteLine("Armstrong Number");
        else
            Console.WriteLine("Not an Armstrong Number");
    }
}
