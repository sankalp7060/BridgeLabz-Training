using System;
using System.Collections.Generic;

class CustomHashMap
{
    class Node
    {
        public int key,
            value;
        public Node? next;

        public Node(int k, int v)
        {
            key = k;
            value = v;
            next = null;
        }
    }

    private Node[] table = new Node[10];

    int Hash(int key) => key % table.Length;

    public void Put(int key, int value)
    {
        int index = Hash(key);
        Node? head = table[index];

        while (head != null)
        {
            if (head.key == key)
            {
                head.value = value;
                return;
            }
            head = head.next;
        }

        Node newNode = new Node(key, value);
        newNode.next = table[index];
        table[index] = newNode;
    }

    public int Get(int key)
    {
        int index = Hash(key);
        Node? head = table[index];

        while (head != null)
        {
            if (head.key == key)
                return head.value;
            head = head.next;
        }
        return -1;
    }

    static void Main()
    {
        CustomHashMap map = new CustomHashMap();
        map.Put(1, 100);
        map.Put(11, 200);

        Console.WriteLine(map.Get(1));
        Console.WriteLine(map.Get(11));
    }
}
