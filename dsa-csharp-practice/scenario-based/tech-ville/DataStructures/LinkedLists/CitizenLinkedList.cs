using TechVille.DSA.Models;

namespace TechVille.DSA.DataStructures.LinkedLists
{
    // Singly linked list for citizen network
    public class CitizenLinkedList
    {
        class Node
        {
            public Citizen Data;
            public Node Next;

            public Node(Citizen c)
            {
                Data = c;
            }
        }

        private Node head;

        // Insert citizen into network
        public void Add(Citizen c)
        {
            Node n = new Node(c);

            if (head == null)
                head = n;
            else
            {
                Node temp = head;
                while (temp.Next != null)
                    temp = temp.Next;
                temp.Next = n;
            }
        }

        public void Display()
        {
            Node t = head;
            while (t != null)
            {
                System.Console.WriteLine(t.Data.Name);
                t = t.Next;
            }
        }
    }
}
