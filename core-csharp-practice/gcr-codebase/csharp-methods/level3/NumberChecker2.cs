using System; 

class NumberChecker2{
    //Main() 
    static void Main(){
        Console.WriteLine("Enter a number:- "); //Asking user to enter a number
        int number = int.Parse(Console.ReadLine()); //Reading number from user

        int digitCount = CountDigits(number); //Calling method to count digits
        int[] digits = StoreDigits(number, digitCount); //Calling method to store digits in array

        int sumOfDigits = FindSumOfDigits(digits); //Calling method to find sum of digits
        int sumOfSquares = FindSumOfSquaresOfDigits(digits); //Calling method to find sum of squares
        bool isHarshad = IsHarshadNumber(number, sumOfDigits); //Checking Harshad number

        int[,] frequency = FindDigitFrequency(digits); //Calling method to find digit frequency

        Console.WriteLine("Sum of Digits : " + sumOfDigits); //Displaying sum of digits
        Console.WriteLine("Sum of Squares of Digits : " + sumOfSquares); //Displaying sum of squares
        Console.WriteLine("Is Harshad Number : " + isHarshad); //Displaying Harshad result

        Console.WriteLine("Digit Frequency :-"); //Heading for frequency output
        for(int index = 0; index < frequency.GetLength(0); index++) //Loop through 2D array
        {
            if(frequency[index, 1] > 0) //Checking if frequency exists
            {
                Console.WriteLine("Digit " + frequency[index, 0] + " -> " + frequency[index, 1]); //Printing digit and count
            }
        }
    }

    //Method to count digits in a number
    static int CountDigits(int number){
        int count = 0; //Variable to store digit count

        while(number != 0) //Loop until number becomes zero
        {
            count++; //Incrementing count
            number = number / 10; //Removing last digit
        }

        return count; //Returning digit count
    }

    //Method to store digits of number into array
    static int[] StoreDigits(int number, int count){
        int[] digits = new int[count]; //Creating array to store digits
        int index = 0; //Index variable

        while(number != 0){ //Loop until number becomes zero{
            digits[index] = number % 10; //Extracting last digit
            number = number / 10; //Removing last digit
            index++; //Incrementing index
        }

        return digits; //Returning digits array
    }

    //Method to find sum of digits
    static int FindSumOfDigits(int[] digits){
        int sum = 0; //Variable to store sum

        for(int index = 0; index < digits.Length; index++) //Loop through digits
        {
            sum = sum + digits[index]; //Adding digit to sum
        }

        return sum; //Returning sum
    }

    //Method to find sum of squares of digits
    static int FindSumOfSquaresOfDigits(int[] digits){
        int sum = 0; //Variable to store sum of squares

        for(int index = 0; index < digits.Length; index++) //Loop through digits
        {
            sum = sum + (int)Math.Pow(digits[index], 2); //Adding square of digit
        }

        return sum; //Returning sum of squares
    }

    //Method to check Harshad Number
    static bool IsHarshadNumber(int number, int sumOfDigits){
        if(sumOfDigits == 0) //Checking division by zero condition
        {
            return false; //Returning false
        }

        return number % sumOfDigits == 0; //Checking Harshad condition
    }

    //Method to find digit frequency
    static int[,] FindDigitFrequency(int[] digits){
        int[,] frequency = new int[10, 2]; //Creating 2D array for digits 0–9

        for(int digit = 0; digit <= 9; digit++) //Initializing digit column
        {
            frequency[digit, 0] = digit; //Storing digit
            frequency[digit, 1] = 0; //Initializing frequency as zero
        }

        for(int index = 0; index < digits.Length; index++) //Loop through digits
        {
            frequency[digits[index], 1]++; //Incrementing frequency count
        }

        return frequency; //Returning frequency array
    }
}
