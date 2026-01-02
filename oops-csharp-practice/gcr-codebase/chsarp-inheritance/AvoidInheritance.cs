using System;

abstract class Repository
{
    public abstract void Save();
}

class SqlRepository : Repository
{
    public override void Save() => Console.WriteLine("Saving to SQL");
}

class AvoidInheritance
{
    static void Main()
    {
        Repository r = new SqlRepository();
        r.Save();
    }
}
