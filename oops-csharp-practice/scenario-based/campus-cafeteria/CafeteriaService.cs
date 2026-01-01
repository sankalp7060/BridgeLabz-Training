using System;

class CafeteriaService
{
    private MenuData data = new MenuData();
    private int totalBill = 0;

    public int TotalBill => totalBill;

    public void DisplayMenu()
    {
        Console.WriteLine(
            "\n========================================================================================================="
        );
        Console.WriteLine("                                         Cafeteria Menu");
        Console.WriteLine(
            "=========================================================================================================\n"
        );

        for (int i = 0; i < data.Items.Length; i++)
        {
            Console.WriteLine(
                $"                                       {i + 1}.  {data.Items[i], -35} ${data.Prices[i]}"
            );
        }

        Console.WriteLine(
            "                                       11. I have ordered my items (Exit)"
        );
    }

    // REQUIRED METHOD
    public string GetItemByIndex(int index)
    {
        if (index < 0 || index >= data.Items.Length)
            return null;

        return data.Items[index];
    }

    public bool ProcessOrder(int choice)
    {
        int index = choice - 1;
        string item = GetItemByIndex(index);

        if (item == null)
            return false;

        int price = data.Prices[index];
        AddToBill(price);

        Console.WriteLine($"\n\nAdded: {item} | Price: ${price} | Current Bill: ${totalBill}");

        return true;
    }

    private void AddToBill(int amount)
    {
        totalBill += amount;
    }
}
