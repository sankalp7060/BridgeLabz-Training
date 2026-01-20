using System;

public class AadharUtility : IAadhar
{
    private Aadhar[] aadhars;
    private int size;
    private int count;

    public AadharUtility(int cap)
    {
        size = cap;
        aadhars = new Aadhar[size];
        count = 0;
    }

    public void AddAadharNumber()
    {
        if (count >= size)
        {
            Console.WriteLine("Memory is full:- ");
            return;
        }
        Console.WriteLine("Enter you name:- ");
        string name = Console.ReadLine();
        Console.Write("Enter your Aadhaar number: ");
        string input = Console.ReadLine();

        if (!long.TryParse(input, out long number))
        {
            Console.WriteLine("Invalid Aadhaar Number!");
            return;
        }
        aadhars[count++] = new Aadhar(number, name);
    }

    public void SortAadhar()
    {
        if (count == 0)
        {
            Console.WriteLine("No Aadhaar records to sort!");
            return;
        }

        long max = GetMax();
        for (long i = 1; max / i > 0; i *= 10)
        {
            CountingSort(i);
        }
        Console.WriteLine("Aadhaar Numbers Sorted Successfully!");
    }

    public long GetMax()
    {
        long max = aadhars[0].Number;
        for (int i = 1; i < count; i++)
        {
            max = aadhars[i].Number > max ? aadhars[i].Number : max;
        }
        return max;
    }

    public void CountingSort(long exp)
    {
        int[] countArray = new int[10];
        Aadhar[] output = new Aadhar[count];
        for (int i = 0; i < count; i++)
        {
            int digit = (int)((aadhars[i].Number / exp) % 10);
            countArray[digit]++;
        }
        for (int i = 1; i < 10; i++)
        {
            countArray[i] += countArray[i - 1];
        }

        for (int i = count - 1; i >= 0; i--)
        {
            int digit = (int)((aadhars[i].Number / exp) % 10);
            output[countArray[digit] - 1] = aadhars[i];
            countArray[digit]--;
        }
        for (int i = 0; i < count; i++)
        {
            aadhars[i] = output[i];
        }
    }

    public void SearchAadhar()
    {
        SortAadhar();

        Console.WriteLine("Enter the aadhar number to be searched:- ");
        string input = Console.ReadLine();
        if (!long.TryParse(input, out long target))
        {
            Console.WriteLine("Invalid Aadhaar Number!");
            return;
        }
        int l = 0;
        int r = count - 1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            if (aadhars[mid].Number == target)
            {
                Console.WriteLine("Found: " + aadhars[mid]);
                return;
            }
            else if (aadhars[mid].Number < target)
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }
    }

    public void Display()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(aadhars[i]);
        }
    }
}
