using System; 

class CollinearCheck {
    //Main() 
    static void Main(){
        bool bySlope = CheckCollinearBySlope(2,4,4,6,6,8); //Slope check
        bool byArea = CheckCollinearByArea(2,4,4,6,6,8); //Area check

        Console.WriteLine("Collinear by Slope : " + bySlope); //Displaying slope result
        Console.WriteLine("Collinear by Area  : " + byArea); //Displaying area result
    }

    //Method using slope
    static bool CheckCollinearBySlope(double x1,double y1,double x2,double y2,double x3,double y3){
        double slope1 = (y2 - y1) / (x2 - x1); //Slope AB
        double slope2 = (y3 - y2) / (x3 - x2); //Slope BC
        double slope3 = (y3 - y1) / (x3 - x1); //Slope AC

        return slope1 == slope2 && slope2 == slope3; //Checking equality
    }

    //Method using area
    static bool CheckCollinearByArea(double x1,double y1,double x2,double y2,double x3,double y3){
        double area = 0.5 * (x1*(y2-y3) + x2*(y3-y1) + x3*(y1-y2)); //Area formula
        return area == 0; //Checking collinearity
    }
}
