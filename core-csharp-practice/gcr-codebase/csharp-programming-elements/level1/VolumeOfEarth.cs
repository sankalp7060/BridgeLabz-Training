using System;

class VolumeOfEarth{
    //Main()
    static void Main(String[] args){
        double radius = 6378; //Radius of earth
        double volumeKm = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3); //volume in kilometers
        double volumeMiles = volumeKm * 0.239913; //Volume in miles
        Console.WriteLine($"The volume of earth in kilometers is {volumeKm} and miles is {volumeMiles}"); //Output
    }
}
