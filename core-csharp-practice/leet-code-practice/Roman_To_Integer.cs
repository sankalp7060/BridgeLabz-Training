using System;

class Roman_To_Integer{
    // Main function
    public static void Main(string[] args){
        string romanNum = Console.ReadLine().ToUpper(); // Roman number to be converted into integer
        int intNum = romanToInt(romanNum); // variable to store the output of the romanToInt function
        Console.Write(intNum); // output
    }

    // function to convert roman number to integer number
    public static int romanToInt(string romanNum){
        int intNum = 0, num = 0;
        for (int i = romanNum.Length - 1; i >= 0; i--){
            switch (romanNum[i]){
                case 'I':
                    num = 1;
                    break;
                case 'V':
                    num = 5;
                    break;
                case 'X':
                    num = 10;
                    break;
                case 'L':
                    num = 50;
                    break;
                case 'C':
                    num = 100;
                    break;
                case 'D':
                    num = 500;
                    break;
                case 'M':
                    num = 1000;
                    break;
            }
            if (4 * num < intNum)
                intNum -= num;
            else
                intNum += num;
        }
        return intNum;
    }
}
