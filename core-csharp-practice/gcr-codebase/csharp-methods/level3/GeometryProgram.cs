using System; 

class GeometryProgram{
    //Main() 
    static void Main(){
        Console.WriteLine("Enter x1:- "); //Input x1
        double x1 = double.Parse(Console.ReadLine()); //Reading x1

        Console.WriteLine("Enter y1:- "); //Input y1
        double y1 = double.Parse(Console.ReadLine()); //Reading y1

        Console.WriteLine("Enter x2:- "); //Input x2
        double x2 = double.Parse(Console.ReadLine()); //Reading x2

        Console.WriteLine("Enter y2:- "); //Input y2
        double y2 = double.Parse(Console.ReadLine()); //Reading y2

        double distance = FindDistance(x1, y1, x2, y2); //Calculating distance
        double[] line = FindLineEquation(x1, y1, x2, y2); //Finding line equation

        Console.WriteLine("Distance : " + distance); //Displaying distance
        Console.WriteLine("Equation : y = " + line[0] + "x + " + line[1]); //Displaying equation
    }

    //Method to find distance
    static double FindDistance(double x1, double y1, double x2, double y2){
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); //Distance formula
    }

    //Method to find line equation
    static double[] FindLineEquation(double x1, double y1, double x2, double y2){
        double m = (y2 - y1) / (x2 - x1); //Calculating slope
        double b = y1 - m * x1; //Calculating intercept
        return new double[] { m, b }; //Returning slope and intercept
    }
}
