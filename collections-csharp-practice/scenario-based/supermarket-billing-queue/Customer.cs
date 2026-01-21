using System.Collections.Generic;

public class Customer
{
    public string Name { get; set; }
    public List<string> CartItems { get; set; }

    public Customer(string name)
    {
        Name = name;
        CartItems = new List<string>();
    }
}
