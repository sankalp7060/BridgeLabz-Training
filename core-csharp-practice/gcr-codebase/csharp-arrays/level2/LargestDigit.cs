using System;

class LargestDigit{
    //Main()
    static void Main(){
        Console.Write("Enter a number: ");
        long num = long.Parse(Console.ReadLine());//User given number value

        int maxDigit = 10;
        int[] digits = new int[maxDigit];
        int i = 0; // Index to track the element of digits array

        // Store all the digits of the number in digits array
        while (num != 0){
            int digit = (int)(num % 10);
            num /= 10;

            // If array full, increase the size
            if (i == maxDigit){
                maxDigit += 10;
                int[] temp = new int[maxDigit];
                Array.Copy(digits, temp, digits.Length);
                digits = temp;
            }

            digits[i] = digit;
            i++;
        }

        // Variable to store largest and second largest number 
        int largest = -1, secondLargest = -1;

        //Find largest and second largest
        for (int j = 0; j < i; j++){
            if (digits[j] > largest){
                secondLargest = largest;
                largest = digits[j];
            }
            else if (digits[j] > secondLargest && digits[j] != largest){
                secondLargest = digits[j];
            }
        }

        Console.WriteLine($"\nLargest Digit = {largest}");
        Console.WriteLine($"Second Largest Digit = {secondLargest}");
    }
}
