using System; 

class NumberChecker {
    //Main() 
    static void Main()
    {
        Console.WriteLine("Enter a number:- "); //Asking user for input number
        int number = int.Parse(Console.ReadLine()); //Reading user input and converting to integer

        int digitCount = CountDigits(number); //Calling method to count digits
        int[] digits = StoreDigits(number, digitCount); //Calling method to store digits in array

        bool isDuck = IsDuckNumber(digits); //Checking whether number is Duck number
        bool isArmstrong = IsArmstrongNumber(number, digits); //Checking whether number is Armstrong number

        int[] largest = FindLargestAndSecondLargest(digits); //Finding largest and second largest digit
        int[] smallest = FindSmallestAndSecondSmallest(digits); //Finding smallest and second smallest digit

        Console.WriteLine("Is Duck Number : " + isDuck); //Displaying Duck number result
        Console.WriteLine("Is Armstrong Number : " + isArmstrong); //Displaying Armstrong number result

        Console.WriteLine("Largest Digit : " + largest[0]); //Displaying largest digit
        Console.WriteLine("Second Largest Digit : " + largest[1]); //Displaying second largest digit

        Console.WriteLine("Smallest Digit : " + smallest[0]); //Displaying smallest digit
        Console.WriteLine("Second Smallest Digit : " + smallest[1]); //Displaying second smallest digit
    }

    //Method to count digits in a number
    static int CountDigits(int number)
    {
        int count = 0; //Variable to store digit count

        while(number != 0) //Loop until number becomes zero
        {
            count++; //Incrementing digit count
            number = number / 10; //Removing last digit
        }

        return count; //Returning digit count
    }

    //Method to store digits of number into array
    static int[] StoreDigits(int number, int count)
    {
        int[] digits = new int[count]; //Creating array of size digit count
        int index = 0; //Index variable for array

        while(number != 0) //Loop until number becomes zero
        {
            digits[index] = number % 10; //Extracting last digit
            number = number / 10; //Removing last digit
            index++; //Incrementing array index
        }

        return digits; //Returning digits array
    }

    //Method to check Duck Number
    static bool IsDuckNumber(int[] digits)
    {
        for(int index = 0; index < digits.Length; index++) //Loop through digits array
        {
            if(digits[index] == 0) //Checking if digit is zero
            {
                return true; //Returning true if zero is found
            }
        }

        return false; //Returning false if no zero found
    }

    //Method to check Armstrong Number
    static bool IsArmstrongNumber(int originalNumber, int[] digits)
    {
        int sum = 0; //Variable to store sum of powered digits
        int power = digits.Length; //Power is number of digits

        for(int index = 0; index < digits.Length; index++) //Loop through digits
        {
            sum = sum + (int)Math.Pow(digits[index], power); //Adding powered digit
        }

        return sum == originalNumber; //Checking Armstrong condition
    }

    //Method to find largest and second largest digit
    static int[] FindLargestAndSecondLargest(int[] digits)
    {
        int largest = Int32.MinValue; //Initializing largest with minimum value
        int secondLargest = Int32.MinValue; //Initializing second largest

        for(int index = 0; index < digits.Length; index++) //Loop through digits
        {
            if(digits[index] > largest) //Checking if digit is greater than largest
            {
                secondLargest = largest; //Updating second largest
                largest = digits[index]; //Updating largest
            }
            else if(digits[index] > secondLargest && digits[index] != largest) //Checking second largest
            {
                secondLargest = digits[index]; //Updating second largest
            }
        }

        return new int[] { largest, secondLargest }; //Returning result array
    }

    //Method to find smallest and second smallest digit
    static int[] FindSmallestAndSecondSmallest(int[] digits)
    {
        int smallest = Int32.MaxValue; //Initializing smallest with maximum value
        int secondSmallest = Int32.MaxValue; //Initializing second smallest

        for(int index = 0; index < digits.Length; index++) //Loop through digits
        {
            if(digits[index] < smallest) //Checking if digit is smaller
            {
                secondSmallest = smallest; //Updating second smallest
                smallest = digits[index]; //Updating smallest
            }
            else if(digits[index] < secondSmallest && digits[index] != smallest) //Checking second smallest
            {
                secondSmallest = digits[index]; //Updating second smallest
            }
        }

        return new int[] { smallest, secondSmallest }; //Returning result array
    }
}
