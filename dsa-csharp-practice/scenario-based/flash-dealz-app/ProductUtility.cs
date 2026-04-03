using System;

public class ProductUtility : IProduct
{
    public void SortProduct(Product[] products)
    {
        Sort(products, 0, products.Length - 1);
    }

    public void Sort(Product[] products, int l, int r)
    {
        if (l < r)
        {
            int pivot = Partition(products, l, r);
            Sort(products, l, pivot - 1);
            Sort(products, pivot + 1, r);
        }
    }

    public int Partition(Product[] products, int l, int r)
    {
        double pivot = products[r].Discount;
        int i = l - 1;
        for (int j = l; j < r; j++)
        {
            if (products[j].Discount < pivot)
            {
                i++;
                Swap(products, i, j);
            }
        }
        Swap(products, i + 1, r);
        return i + 1;
    }

    public void Swap(Product[] products, int i, int j)
    {
        Product t = products[i];
        products[i] = products[j];
        products[j] = t;
    }

    public void Display(Product[] products)
    {
        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine(products[i]);
        }
    }
}
