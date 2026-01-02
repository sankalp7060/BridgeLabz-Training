using System;

class BaseClass
{
    public virtual void Process() => Console.WriteLine("Base processing");
}

class DerivedClass : BaseClass
{
    public override void Process()
    {
        base.Process();
        Console.WriteLine("Derived processing");
    }
}

class FragileBaseClass
{
    static void Main()
    {
        BaseClass b = new DerivedClass();
        b.Process();
    }
}
