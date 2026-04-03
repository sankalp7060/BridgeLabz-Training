using System;

class LargestAndSecondLargestDigit{
    //Main()
    static void Main(){
        // User given number num
        Console.Write("Enter a number: ");
        long num = long.Parse(Console.ReadLine());

        // Take initial maximum size of the digits array beacuase there are onyl 10 digits 0 to 9
        int maxDigit = 10;

        // Integer array to store digits of the number
        int[] digits = new int[maxDigit];

        // Index to track current position in array
        int index = 0;

        // Extract digits until number becomes 0 using loop
        while (num != 0){
            // If array is full, increase its size by 10
            if (index == maxDigit){
                // Increase maxDigit by 10
                maxDigit += 10;

                // Create a new temporary array with increased size
                int[] temp = new int[maxDigit];

                // Copy existing digits into the new array
                for (int i = 0; i < digits.Length; i++){
                    temp[i] = digits[i];
                }

                // Assign temp array back to digits array
                digits = temp;
            }

            // Extract last digit
            digits[index] = (int)(num % 10);

            // Remove last digit from number
            num = num / 10;

            // Move to next index
            index++;
        }

        // Variables to store largest and second largest digits
        int largest = -1;
        int secondLargest = -1;

        // Find largest and second largest digit using loop
        for (int i = 0; i < index; i++){
            if (digits[i] > largest){
                // Update second largest before updating largest
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] != largest){
                // Update second largest if digit is smaller than largest
                secondLargest = digits[i];
            }
        }

        // Display results
        Console.WriteLine("\nLargest Digit = " + largest);
        Console.WriteLine("Second Largest Digit = " + secondLargest);
    }
}
