using System;

class Vehicle
{
    public void Move() => Console.WriteLine("Vehicle moving");
}

class Car : Vehicle { }

class VehicleCar
{
    static void Main()
    {
        Car car = new Car();
        car.Move();
    }
}
