using System;

public class CustomHashMap
{
    private HashNode[] bucket = new HashNode[100];

    public int GetIndex(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += c;
        }
        return hash % 100;
    }

    public void Put(string key, Book book)
    {
        int index = GetIndex(key);
        if (bucket[index] == null)
        {
            bucket[index] = new HashNode(key);
        }
        HashNode current = bucket[index];

        while (true)
        {
            if (current.Key == key)
            {
                if (current.Value.Contains(book.Id))
                {
                    Console.WriteLine("Book already exist ");
                    return;
                }
                current.Value.Add(book);
                Console.WriteLine("Book Added Successfully");
                return;
            }
            if (current.Next == null)
                break;
            current = current.Next;
        }
        current.Next = new HashNode(key);
        current.Next.Value.Add(book);
    }

    public BookLinkedList Get(string key)
    {
        int index = GetIndex(key);
        HashNode node = bucket[index];
        while (node != null)
        {
            if (node.Key == key)
            {
                return node.Value;
            }
            node = node.Next;
        }
        return null;
    }

    public bool Remove(string key, int id)
    {
        BookLinkedList list = Get(key);
        if (list == null)
        {
            return false;
        }
        return list.Remove(id);
    }

    public void Display()
    {
        Console.WriteLine("\nLibrary Catalog ");

        for (int i = 0; i < 100; i++)
        {
            HashNode node = bucket[i];

            while (node != null)
            {
                Console.WriteLine("\nGenre: " + node.Key);

                if (node.Value.IsEmpty())
                {
                    Console.WriteLine("No Books Available");
                }
                else
                {
                    node.Value.Display();
                }

                node = node.Next;
            }
        }
    }
}
