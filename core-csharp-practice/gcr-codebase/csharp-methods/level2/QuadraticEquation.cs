using System;

class QuadraticEquation{
    //Main()
    static void Main(){
        Console.WriteLine("Enter value of a:- ");
        double a = double.Parse(Console.ReadLine()); //User given value of a

        Console.WriteLine("Enter value of b:- ");
        double b = double.Parse(Console.ReadLine()); //User given value of b

        Console.WriteLine("Enter value of c:- ");
        double c = double.Parse(Console.ReadLine()); //User given value of c

        double[] roots = FindRoots(a, b, c); //Find roots of quadratic equation

        if(roots.Length == 0){
            Console.WriteLine("No real roots");
        }else{
            foreach(double root in roots){
                Console.WriteLine("Root:- " + root); //Output roots
            }
        }
    }

    //Method to find roots of quadratic equation
    static double[] FindRoots(double a, double b, double c){
        double delta = Math.Pow(b, 2) - 4 * a * c; //Calculate delta

        if(delta < 0){
            return new double[0]; //No real roots
        }

        if(delta == 0){
            double root = -b / (2 * a);
            return new double[]{ root }; //One root
        }

        double sqrtDelta = Math.Sqrt(delta); //Square root of delta
        double root1 = (-b + sqrtDelta) / (2 * a);
        double root2 = (-b - sqrtDelta) / (2 * a);

        return new double[]{ root1, root2 }; //Return both roots
    }
}
