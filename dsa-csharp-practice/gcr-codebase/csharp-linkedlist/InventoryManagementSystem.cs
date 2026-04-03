using System;

/* ================= ITEM ================= */
class Item
{
    public int ItemId;
    public string ItemName;
    public int Quantity;
    public double Price;

    public Item(int id, string name, int qty, double price)
    {
        ItemId = id;
        ItemName = name;
        Quantity = qty;
        Price = price;
    }
}

/* ================= NODE ================= */
class ItemNode
{
    public Item Data;
    public ItemNode Next;

    public ItemNode(Item item)
    {
        Data = item;
        Next = null;
    }
}

/* ================= LINKED LIST ================= */
class InventoryLinkedList
{
    private ItemNode head;

    /* ---------- ADD OPERATIONS ---------- */
    public void AddAtBeginning()
    {
        Item item = ReadItem();
        ItemNode node = new ItemNode(item);

        node.Next = head;
        head = node;
    }

    public void AddAtEnd()
    {
        Item item = ReadItem();
        ItemNode node = new ItemNode(item);

        if (head == null)
        {
            head = node;
            return;
        }

        ItemNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = node;
    }

    public void AddAtPosition()
    {
        Console.Write("Enter position: ");
        int pos = int.Parse(Console.ReadLine());

        if (pos <= 1 || head == null)
        {
            AddAtBeginning();
            return;
        }

        Item item = ReadItem();
        ItemNode node = new ItemNode(item);

        ItemNode temp = head;
        for (int i = 1; i < pos - 1 && temp.Next != null; i++)
            temp = temp.Next;

        node.Next = temp.Next;
        temp.Next = node;
    }

    /* ---------- REMOVE ---------- */
    public void RemoveById()
    {
        Console.Write("Enter Item ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        if (head == null)
            return;

        if (head.Data.ItemId == id)
        {
            head = head.Next;
            Console.WriteLine("Item removed.");
            return;
        }

        ItemNode temp = head;
        while (temp.Next != null && temp.Next.Data.ItemId != id)
            temp = temp.Next;

        if (temp.Next != null)
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Item removed.");
        }
        else
            Console.WriteLine("Item not found.");
    }

    /* ---------- UPDATE ---------- */
    public void UpdateQuantity()
    {
        Console.Write("Enter Item ID: ");
        int id = int.Parse(Console.ReadLine());

        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.Data.ItemId == id)
            {
                Console.Write("Enter new quantity: ");
                temp.Data.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Quantity updated.");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found.");
    }

    /* ---------- SEARCH ---------- */
    public void SearchById()
    {
        Console.Write("Enter Item ID: ");
        int id = int.Parse(Console.ReadLine());

        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.Data.ItemId == id)
            {
                PrintItem(temp.Data);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found.");
    }

    public void SearchByName()
    {
        Console.Write("Enter Item Name: ");
        string name = Console.ReadLine();

        ItemNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Data.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                PrintItem(temp.Data);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Item not found.");
    }

    /* ---------- TOTAL VALUE ---------- */
    public void CalculateTotalValue()
    {
        double total = 0;
        ItemNode temp = head;

        while (temp != null)
        {
            total += temp.Data.Price * temp.Data.Quantity;
            temp = temp.Next;
        }

        Console.WriteLine($"Total Inventory Value: {total}");
    }

    /* ---------- SORT ---------- */
    public void SortByName(bool ascending)
    {
        for (ItemNode i = head; i != null; i = i.Next)
        {
            for (ItemNode j = i.Next; j != null; j = j.Next)
            {
                if (
                    (ascending && string.Compare(i.Data.ItemName, j.Data.ItemName) > 0)
                    || (!ascending && string.Compare(i.Data.ItemName, j.Data.ItemName) < 0)
                )
                {
                    Swap(i, j);
                }
            }
        }
        Console.WriteLine("Sorted by name.");
    }

    public void SortByPrice(bool ascending)
    {
        for (ItemNode i = head; i != null; i = i.Next)
        {
            for (ItemNode j = i.Next; j != null; j = j.Next)
            {
                if (
                    (ascending && i.Data.Price > j.Data.Price)
                    || (!ascending && i.Data.Price < j.Data.Price)
                )
                {
                    Swap(i, j);
                }
            }
        }
        Console.WriteLine("Sorted by price.");
    }

    /* ---------- DISPLAY ---------- */
    public void DisplayAll()
    {
        ItemNode temp = head;
        if (temp == null)
        {
            Console.WriteLine("Inventory empty.");
            return;
        }

        while (temp != null)
        {
            PrintItem(temp.Data);
            temp = temp.Next;
        }
    }

    /* ---------- HELPERS ---------- */
    private void Swap(ItemNode a, ItemNode b)
    {
        Item temp = a.Data;
        a.Data = b.Data;
        b.Data = temp;
    }

    private Item ReadItem()
    {
        Console.Write("Item ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Item Name: ");
        string name = Console.ReadLine();
        Console.Write("Quantity: ");
        int qty = int.Parse(Console.ReadLine());
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        return new Item(id, name, qty, price);
    }

    private void PrintItem(Item i)
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine($"ID       : {i.ItemId}");
        Console.WriteLine($"Name     : {i.ItemName}");
        Console.WriteLine($"Quantity : {i.Quantity}");
        Console.WriteLine($"Price    : {i.Price}");
    }
}

/* ================= MAIN ================= */
class Program
{
    static void Main()
    {
        InventoryLinkedList inventory = new InventoryLinkedList();

        while (true)
        {
            Console.WriteLine("\n1 Add Begin  2 Add End  3 Add Pos");
            Console.WriteLine("4 Remove    5 Update Qty");
            Console.WriteLine("6 Search ID 7 Search Name");
            Console.WriteLine("8 Total Value");
            Console.WriteLine("9 Sort Name Asc  10 Sort Name Desc");
            Console.WriteLine("11 Sort Price Asc 12 Sort Price Desc");
            Console.WriteLine("13 Display  0 Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    inventory.AddAtBeginning();
                    break;
                case 2:
                    inventory.AddAtEnd();
                    break;
                case 3:
                    inventory.AddAtPosition();
                    break;
                case 4:
                    inventory.RemoveById();
                    break;
                case 5:
                    inventory.UpdateQuantity();
                    break;
                case 6:
                    inventory.SearchById();
                    break;
                case 7:
                    inventory.SearchByName();
                    break;
                case 8:
                    inventory.CalculateTotalValue();
                    break;
                case 9:
                    inventory.SortByName(true);
                    break;
                case 10:
                    inventory.SortByName(false);
                    break;
                case 11:
                    inventory.SortByPrice(true);
                    break;
                case 12:
                    inventory.SortByPrice(false);
                    break;
                case 13:
                    inventory.DisplayAll();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
