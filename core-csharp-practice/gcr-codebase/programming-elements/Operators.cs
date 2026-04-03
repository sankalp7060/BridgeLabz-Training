using System;

class Operators{
    static void Main(String[] args){

        int num1 = 20;
        int num2 = 10;

        //Arithmetic Operators:- Addition, Subtraction, Multiplication, Division, Modulus
        
        int addition = num1 + num2; //Addition
        Console.WriteLine(addition); 

        int subtraction = num1 - num2; //Subtraction
        Console.WriteLine(subtraction);

        int multiplication = num1 * num2; //Multiplication
        Console.WriteLine(multiplication);

        int division = num1 / num2; //Division
        Console.WriteLine(division);

        int modulus = num1 % num2; //Modulus
        Console.WriteLine(modulus);

        //Relational Operators:- Equal To, Not Equal To, Greater Than, Less Than, Greater than or equal to, Less than or equal to
        
        bool equalTo = num1 == num2; //Equal To
        Console.WriteLine(equalTo);

        bool notEqualTo = num1 != num2; //Not Equal To
        Console.WriteLine(notEqualTo);

        bool greaterThan = num1 > num2; //Greater Than
        Console.WriteLine(greaterThan);

        bool lessThan = num1 < num2; //Less Than
        Console.WriteLine(lessThan);

        bool greaterThanOrEqual = num1 >= num2; //Greater Than or Equal To
        Console.WriteLine(greaterThanOrEqual);

        bool lessThanOrEqual = num1 <= num2; //Less Than or Equal To
        Console.WriteLine(lessThanOrEqual);

        //Logical Operators:- AND, OR, NOT

        bool andOperator = (num1 > 5) && (num2 > 5); //AND
        Console.WriteLine(andOperator);

        bool orOperator = (num1 > 25) || (num2 > 5); //OR
        Console.WriteLine(orOperator);

        bool notOperator = !(num1 < num2); //NOT
        Console.WriteLine(notOperator);

        //Assignment Operators:- Assignment, Addition Assignment, Subtraction Assignment, Multiplication Assignment,Division Assignment, Modulus Assignment

        int assign = num1; //Assignment
        Console.WriteLine(assign);

        assign += num2; //Addition Assignment
        Console.WriteLine(assign);

        assign -= num2; //Subtraction Assignment
        Console.WriteLine(assign);

        assign *= num2; //Multiplication Assignment
        Console.WriteLine(assign);

        assign /= num2; //Division Assignment
        Console.WriteLine(assign);

        assign %= num2; //Modulus Assignment
        Console.WriteLine(assign);

        //Unary Operators:- Unary plus, Unary minus, Increment, Decrement, Logical Complement

        int unaryPlus = +num1; //Unary Plus
        Console.WriteLine(unaryPlus);

        int unaryMinus = -num1; //Unary Minus
        Console.WriteLine(unaryMinus);

        num1++; //Increment
        Console.WriteLine(num1);

        num2--; //Decrement
        Console.WriteLine(num2);

        bool logicalComplement = !false; //Logical Complement
        Console.WriteLine(logicalComplement);

        //Bitwise Operators:- AND, OR, XOR, Complement, Left Shift, Right Shift

        int bitwiseAnd = num1 & num2; //AND
        Console.WriteLine(bitwiseAnd);

        int bitwiseOr = num1 | num2; //OR
        Console.WriteLine(bitwiseOr);

        int bitwiseXor = num1 ^ num2; //XOR
        Console.WriteLine(bitwiseXor);

        int bitwiseComplement = ~num1; //Complement
        Console.WriteLine(bitwiseComplement);

        int leftShift = num1 << 1; //Left Shift
        Console.WriteLine(leftShift);

        int rightShift = num1 >> 1; //Right Shift
        Console.WriteLine(rightShift);

        //Ternary Operators

        string ternaryResult = (num1 > num2) ? "num1 is greater" : "num2 is greater";
        Console.WriteLine(ternaryResult);

        //IS Operators 

        object obj = num1; //object reference
        bool isOperator = obj is int; //IS Operator
        Console.WriteLine(isOperator);

    }
}