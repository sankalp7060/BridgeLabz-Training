using System;

public class Square_Root{
    // Main
    public static void Main(string[] args){
        int num = int.Parse(Console.ReadLine());
        int ans = mySqrt(num);
        Console.Write(ans);
    }

    // function to find square root of a number
    public static int mySqrt(int num){
        if (num == 0){
            return 0;
        }
        if (num == 1){
            return 1;
        }
        double t = 0;
        double s = num / 2.0;
        do{
            t = s;
            s = (t + (num / t)) / 2;
        } while ((t - s) != 0);
        return (int)s;
    }
}
