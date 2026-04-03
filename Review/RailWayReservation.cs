using System;

public interface ITrainManager
{
    void AddTrain(int trainNo, int coachCapacity);
    void RemoveTrain(int trainNo);
    void BookSeat(int trainNo, Passenger p);
    void CancelSeat(int trainNo, Passenger p);
    void DisplaySeats(int trainNo);
}

public class Passenger
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Passenger(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override bool Equals(object obj)
    {
        Passenger p = obj as Passenger;
        if (p == null)
            return false;
        return Id == p.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Id}, {Name}";
    }
}

public class Node
{
    public Passenger Data;
    public Node Next;

    public Node(Passenger data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomLL
{
    private Node head;
    private int cap;
    private int count;

    public CustomLL(int cap)
    {
        this.cap = cap;
    }

    public void Add(Passenger p)
    {
        if (count >= cap)
            return;

        Node node = new Node(p);

        if (head == null)
        {
            head = node;
        }
        else
        {
            Node t = head;
            while (t.Next != null)
                t = t.Next;
            t.Next = node;
        }

        count++;
    }

    public bool Remove(Passenger p)
    {
        if (head == null)
            return false;

        if (head.Data.Equals(p))
        {
            head = head.Next;
            count--;
            return true;
        }

        Node t = head;

        while (t.Next != null)
        {
            if (t.Next.Data.Equals(p))
            {
                t.Next = t.Next.Next;
                count--;
                return true;
            }
            t = t.Next;
        }

        return false;
    }

    public bool Contains(Passenger p)
    {
        Node t = head;

        while (t != null)
        {
            if (t.Data.Equals(p))
                return true;
            t = t.Next;
        }

        return false;
    }

    public bool HasFreeSeat()
    {
        return count < cap;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public void Display()
    {
        Node t = head;

        while (t != null)
        {
            Console.WriteLine(t.Data.Name);
            t = t.Next;
        }
    }
}

public class CustomQ
{
    private Node front;
    private Node rear;

    public void Enqueue(Passenger p)
    {
        Node node = new Node(p);

        if (rear == null)
        {
            front = rear = node;
            return;
        }

        rear.Next = node;
        rear = node;
    }

    public Passenger Dequeue()
    {
        if (front == null)
            return null;

        Passenger value = front.Data;
        front = front.Next;

        if (front == null)
            rear = null;

        return value;
    }

    public bool IsEmpty()
    {
        return front == null;
    }

    public bool Contains(Passenger p)
    {
        Node t = front;

        while (t != null)
        {
            if (t.Data.Equals(p))
                return true;
            t = t.Next;
        }

        return false;
    }
}

public class TrainEntry
{
    public int TrainNo { get; private set; }
    public CustomLL Coach;
    public CustomQ Waiting;

    public TrainEntry(int trainNo, int cap)
    {
        TrainNo = trainNo;
        Coach = new CustomLL(cap);
        Waiting = new CustomQ();
    }
}

public class MapNode
{
    public TrainEntry Data;
    public MapNode Next;

    public MapNode(TrainEntry data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomMap
{
    private MapNode[] table;
    private int size = 20;
    private int count;

    public CustomMap()
    {
        table = new MapNode[size];
    }

    public int Hash(int key)
    {
        return key % size;
    }

    public bool IsFull()
    {
        return count >= size;
    }

    public bool Put(TrainEntry entry)
    {
        if (IsFull())
            return false;

        int index = Hash(entry.TrainNo);
        MapNode head = table[index];

        if (head == null)
        {
            table[index] = new MapNode(entry);
            count++;
            return true;
        }

        MapNode current = head;

        while (current != null)
        {
            if (current.Data.TrainNo == entry.TrainNo)
                return false;
            if (current.Next == null)
                break;
            current = current.Next;
        }

        current.Next = new MapNode(entry);
        count++;
        return true;
    }

    public TrainEntry Get(int trainNo)
    {
        int index = Hash(trainNo);
        MapNode current = table[index];

        while (current != null)
        {
            if (current.Data.TrainNo == trainNo)
                return current.Data;
            current = current.Next;
        }

        return null;
    }

    public bool Remove(int trainNo)
    {
        int index = Hash(trainNo);

        MapNode current = table[index];
        MapNode prev = null;

        while (current != null)
        {
            if (current.Data.TrainNo == trainNo)
            {
                if (prev == null)
                    table[index] = current.Next;
                else
                    prev.Next = current.Next;

                count--;
                return true;
            }

            prev = current;
            current = current.Next;
        }

        return false;
    }
}

public abstract class BaseTrainManager
{
    protected CustomMap trains = new CustomMap();

    protected void AddTrainBase(int trainNo, int coachCapacity)
    {
        TrainEntry entry = new TrainEntry(trainNo, coachCapacity);
        trains.Put(entry);
    }

    protected void RemoveTrainBase(int trainNo)
    {
        trains.Remove(trainNo);
    }

    protected TrainEntry GetTrain(int trainNo)
    {
        return trains.Get(trainNo);
    }
}

public class RailwayManager : BaseTrainManager, ITrainManager
{
    public void AddTrain(int trainNo, int coachCapacity)
    {
        AddTrainBase(trainNo, coachCapacity);
    }

    public void RemoveTrain(int trainNo)
    {
        RemoveTrainBase(trainNo);
    }

    public void BookSeat(int trainNo, Passenger p)
    {
        TrainEntry train = GetTrain(trainNo);

        if (train == null)
            return;

        if (train.Coach.Contains(p))
            return;

        if (train.Coach.HasFreeSeat())
        {
            train.Coach.Add(p);
            Console.WriteLine($"Confirmed: {p.Name}");
        }
        else
        {
            if (train.Waiting.Contains(p))
                return;

            train.Waiting.Enqueue(p);
            Console.WriteLine($"Waiting: {p.Name}");
        }
    }

    public void CancelSeat(int trainNo, Passenger p)
    {
        TrainEntry train = GetTrain(trainNo);

        if (train == null)
            return;

        bool removed = train.Coach.Remove(p);

        if (!removed)
            return;

        Console.WriteLine($"Cancelled: {p.Name}");

        Passenger next = train.Waiting.Dequeue();

        if (next != null)
        {
            train.Coach.Add(next);
            Console.WriteLine($"Moved From Waiting: {next.Name}");
        }
    }

    public void DisplaySeats(int trainNo)
    {
        TrainEntry train = GetTrain(trainNo);

        if (train == null)
            return;

        Console.WriteLine($"Train {trainNo}");

        if (train.Coach.IsEmpty())
        {
            Console.WriteLine("No Confirmed Passengers");
        }
        else
        {
            train.Coach.Display();
        }
    }
}

sealed class RailWayReservationMain
{
    public static void Start()
    {
        ITrainManager manager = new RailwayManager();

        manager.AddTrain(101, 2);

        Passenger p1 = new Passenger(1, "Aman");
        Passenger p2 = new Passenger(2, "Ravi");
        Passenger p3 = new Passenger(3, "Neha");

        manager.BookSeat(101, p1);
        manager.BookSeat(101, p2);
        manager.BookSeat(101, p3);

        Console.WriteLine();
        manager.DisplaySeats(101);

        Console.WriteLine();
        manager.CancelSeat(101, p1);

        Console.WriteLine();
        manager.DisplaySeats(101);
    }
}

class RailWayReservation
{
    static void Main()
    {
        RailWayReservationMain.Start();
    }
}
