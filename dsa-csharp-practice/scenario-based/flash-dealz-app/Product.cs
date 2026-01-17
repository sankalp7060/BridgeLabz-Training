public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public double Discount { get; private set; }

    public Product(int id, string name, double discount)
    {
        Id = id;
        Name = name;
        Discount = discount;
    }

    public override string ToString()
    {
        return $"{Id}, {Name}, {Discount}";
    }
}
