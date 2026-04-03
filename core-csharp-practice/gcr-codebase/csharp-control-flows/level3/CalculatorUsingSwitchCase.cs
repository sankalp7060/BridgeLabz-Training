using System;

class CalculatorUsingSwitchCase{
    //Main()
    static void Main(){
        Console.WriteLine("Enter first and second number:- ");
        double first = double.Parse(Console.ReadLine()); //User given first number value
        double second = double.Parse(Console.ReadLine()); //User given second number value
        string op = Console.ReadLine(); //User given operation

        //Calculator suing switch case
        switch (op){
            //If op = '+' then addition will takes place
            case "+":
                Console.WriteLine(first + second);
                break;
            
            //If op = '-' then subtraction will takes place
            case "-":
                Console.WriteLine(first - second);
                break;

            //If op = '*' then multiplication will takes place
            case "*":
                Console.WriteLine(first * second);
                break;

            //If op = '/' then division will takes place
            case "/":
                Console.WriteLine(first / second);
                break;

            //If none of the opertion is there then default will run
            default:
                Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
