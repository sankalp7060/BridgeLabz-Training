using System;

public class QNode
{
    public Submission Data;
    public QNode Next;

    public QNode(Submission data)
    {
        Data = data;
        Next = null;
    }
}

public class CustomQueue
{
    private QNode front;
    private QNode rear;

    public void Enqueue(Submission s)
    {
        QNode node = new QNode(s);
        if (rear == null)
        {
            front = rear = node;
            return;
        }
        rear.Next = node;
        rear = node;
    }

    public Submission Dequeue()
    {
        if (front == null)
            return null;
        Submission val = front.Data;
        front = front.Next;
        if (front == null)
            rear = null;
        return val;
    }

    public bool IsEmpty() => front == null;

    public void Display()
    {
        QNode t = front;
        while (t != null)
        {
            Console.WriteLine(t.Data);
            t = t.Next;
        }
    }
}
