public class MapNode
{
    public int Id;
    public string Question;
    public MapNode Next;

    public MapNode(int id, string question)
    {
        Id = id;
        Question = question;
        Next = null;
    }
}

public class CustomMap
{
    private MapNode[] table;
    private int size = 20;

    public CustomMap()
    {
        table = new MapNode[size];
    }

    private int Hash(int id, string question)
    {
        int hash = id;
        foreach (var c in question)
            hash += c;
        return hash % size;
    }

    public bool Put(int id, string question)
    {
        int index = Hash(id, question);
        MapNode node = table[index];
        while (node != null)
        {
            if (node.Id == id && node.Question == question)
                return false;
            node = node.Next;
        }
        node = new MapNode(id, question);
        node.Next = table[index];
        table[index] = node;
        return true;
    }

    public bool Contains(int id, string question)
    {
        int index = Hash(id, question);
        MapNode node = table[index];

        while (node != null)
        {
            if (node.Id == id && node.Question == question)
                return true;
            node = node.Next;
        }
        return false;
    }

    public void Remove(int id, string question)
    {
        int index = Hash(id, question);
        MapNode node = table[index];
        MapNode prev = null;

        while (node != null)
        {
            if (node.Id == id && node.Question == question)
            {
                if (prev == null)
                    table[index] = node.Next;
                else
                    prev.Next = node.Next;
                return;
            }
            prev = node;
            node = node.Next;
        }
    }
}
