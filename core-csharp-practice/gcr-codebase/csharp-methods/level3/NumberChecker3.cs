using System; 

class NumberChecker3{
    //Main() 
    static void Main(){
        Console.WriteLine("Enter a number:- "); //Asking user for input
        int number = int.Parse(Console.ReadLine()); //Reading number from user

        int digitCount = CountDigits(number); //Counting digits
        int[] digits = StoreDigits(number, digitCount); //Storing digits in array
        int[] reversedDigits = ReverseDigits(digits); //Reversing digits array

        bool isPalindrome = CompareArrays(digits, reversedDigits); //Checking palindrome
        bool isDuck = IsDuckNumber(digits); //Checking duck number

        Console.WriteLine("Is Palindrome Number : " + isPalindrome); //Displaying palindrome result
        Console.WriteLine("Is Duck Number : " + isDuck); //Displaying duck number result
    }

    //Method to count digits
    static int CountDigits(int number){
        int count = 0; //Variable to store digit count

        while(number != 0) //Loop until number becomes zero
        {
            count++; //Incrementing count
            number = number / 10; //Removing last digit
        }

        return count; //Returning count
    }

    //Method to store digits
    static int[] StoreDigits(int number, int count){
        int[] digits = new int[count]; //Creating digits array
        int index = 0; //Index variable

        while(number != 0) //Loop until number becomes zero
        {
            digits[index] = number % 10; //Extracting digit
            number = number / 10; //Removing last digit
            index++; //Incrementing index
        }

        return digits; //Returning digits array
    }

    //Method to reverse digits array
    static int[] ReverseDigits(int[] digits){
        int[] reversed = new int[digits.Length]; //Creating reversed array

        for(int index = 0; index < digits.Length; index++) //Loop through digits
        {
            reversed[index] = digits[digits.Length - 1 - index]; //Reversing order
        }

        return reversed; //Returning reversed array
    }

    //Method to compare two arrays
    static bool CompareArrays(int[] array1, int[] array2){
        for(int index = 0; index < array1.Length; index++) //Loop through arrays
        {
            if(array1[index] != array2[index]) //Checking mismatch
            {
                return false; //Returning false
            }
        }

        return true; //Returning true if equal
    }

    //Method to check Duck Number
    static bool IsDuckNumber(int[] digits){
        for(int index = 0; index < digits.Length; index++){
            if(digits[index] == 0) //Checking zero
            {
                return true; //Returning true
            }
        }

        return false; //Returning false
    }
}
