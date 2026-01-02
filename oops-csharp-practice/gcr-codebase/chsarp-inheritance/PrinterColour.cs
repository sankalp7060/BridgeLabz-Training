using System;

class Printer
{
    public virtual void Print() => Console.WriteLine("Printing");
}

class ColorPrinter : Printer
{
    public override void Print() => Console.WriteLine("Color printing");
}

class PrinterColour
{
    static void Main()
    {
        Printer p = new ColorPrinter();
        p.Print();
    }
}
