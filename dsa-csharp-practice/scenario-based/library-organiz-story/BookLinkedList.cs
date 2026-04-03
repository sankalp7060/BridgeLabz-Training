using System;

public class BookLinkedList
{
    private BookNode head;

    public void Add(Book book)
    {
        BookNode node = new BookNode(book);
        if (head == null)
        {
            head = node;
            return;
        }
        BookNode t = head;
        while (t.Next != null)
        {
            t = t.Next;
        }
        t.Next = node;
    }

    public bool Remove(int id)
    {
        if (head == null)
        {
            Console.WriteLine("No book");
            return false;
        }
        if (head.Data.Id == id)
        {
            head = head.Next;
            return true;
        }
        BookNode t = head;
        while (t.Next != null && t.Next.Data.Id != id)
        {
            t = t.Next;
        }
        if (t.Next != null)
        {
            t.Next = t.Next.Next;
            return true;
        }
        return false;
    }

    public bool Contains(int id)
    {
        BookNode t = head;
        while (t != null)
        {
            if (t.Data.Id == id)
                return true;

            t = t.Next;
        }
        return false;
    }

    public void Display()
    {
        BookNode t = head;
        while (t != null)
        {
            Console.WriteLine("   " + t.Data);
            t = t.Next;
        }
    }

    public bool IsEmpty()
    {
        return head == null;
    }
}
