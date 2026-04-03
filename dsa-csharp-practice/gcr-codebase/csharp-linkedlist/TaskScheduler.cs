using System;

public class TaskItem
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }

    public TaskItem(int id, string name, int priority, DateTime dueDate)
    {
        TaskId = id;
        TaskName = name;
        Priority = priority;
        DueDate = dueDate;
    }
}

public class TaskNode
{
    public TaskItem Data;
    public TaskNode Next;

    public TaskNode(TaskItem task)
    {
        Data = task;
        Next = null;
    }
}

public interface ITaskScheduler
{
    void AddAtBeginning();
    void AddAtEnd();
    void AddAtPosition();
    void RemoveByTaskId();
    void ViewCurrentAndMoveNext();
    void DisplayAll();
    void SearchByPriority();
}

public class TaskSchedulerImpl : ITaskScheduler
{
    private TaskNode head;
    private TaskNode current;

    // Add at beginning
    public void AddAtBeginning()
    {
        TaskItem task = ReadTask();
        TaskNode node = new TaskNode(task);

        if (head == null)
        {
            head = node;
            node.Next = node;
            current = head;
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        node.Next = head;
        temp.Next = node;
        head = node;
    }

    // Add at end
    public void AddAtEnd()
    {
        TaskItem task = ReadTask();
        TaskNode node = new TaskNode(task);

        if (head == null)
        {
            head = node;
            node.Next = node;
            current = head;
            return;
        }

        TaskNode temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        temp.Next = node;
        node.Next = head;
    }

    // Add at specific position
    public void AddAtPosition()
    {
        Console.Write("Enter position: ");
        int pos = int.Parse(Console.ReadLine());

        if (pos <= 1 || head == null)
        {
            AddAtBeginning();
            return;
        }

        TaskItem task = ReadTask();
        TaskNode node = new TaskNode(task);

        TaskNode temp = head;
        for (int i = 1; i < pos - 1 && temp.Next != head; i++)
            temp = temp.Next;

        node.Next = temp.Next;
        temp.Next = node;
    }

    // Remove by Task ID
    public void RemoveByTaskId()
    {
        Console.Write("Enter Task ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        TaskNode prev = null;

        do
        {
            if (temp.Data.TaskId == id)
            {
                if (prev == null)
                {
                    TaskNode last = head;
                    while (last.Next != head)
                        last = last.Next;

                    if (head == head.Next)
                    {
                        head = null;
                        current = null;
                        return;
                    }

                    head = head.Next;
                    last.Next = head;
                }
                else
                {
                    prev.Next = temp.Next;
                }

                Console.WriteLine("Task removed.");
                return;
            }

            prev = temp;
            temp = temp.Next;
        } while (temp != head);

        Console.WriteLine("Task not found.");
    }

    // View current and move next
    public void ViewCurrentAndMoveNext()
    {
        if (current == null)
        {
            Console.WriteLine("No tasks scheduled.");
            return;
        }

        DisplayTask(current.Data);
        current = current.Next;
    }

    // Display all tasks
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        do
        {
            DisplayTask(temp.Data);
            temp = temp.Next;
        } while (temp != head);
    }

    // Search by priority
    public void SearchByPriority()
    {
        Console.Write("Enter priority: ");
        int priority = int.Parse(Console.ReadLine());

        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode temp = head;
        bool found = false;

        do
        {
            if (temp.Data.Priority == priority)
            {
                DisplayTask(temp.Data);
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No task found with given priority.");
    }

    // Helpers
    private TaskItem ReadTask()
    {
        Console.Write("Task ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Task Name: ");
        string name = Console.ReadLine();

        Console.Write("Priority: ");
        int priority = int.Parse(Console.ReadLine());

        Console.Write("Due Date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        return new TaskItem(id, name, priority, date);
    }

    private void DisplayTask(TaskItem t)
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine($"ID       : {t.TaskId}");
        Console.WriteLine($"Name     : {t.TaskName}");
        Console.WriteLine($"Priority : {t.Priority}");
        Console.WriteLine($"Due Date : {t.DueDate.ToShortDateString()}");
    }
}

public class TaskMenu
{
    private ITaskScheduler scheduler;

    public TaskMenu(ITaskScheduler scheduler)
    {
        this.scheduler = scheduler;
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n1. Add at Beginning");
        Console.WriteLine("2. Add at End");
        Console.WriteLine("3. Add at Position");
        Console.WriteLine("4. Remove by Task ID");
        Console.WriteLine("5. View Current & Move Next");
        Console.WriteLine("6. Display All Tasks");
        Console.WriteLine("7. Search by Priority");
        Console.WriteLine("0. Exit");

        Console.Write("Enter choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                scheduler.AddAtBeginning();
                break;
            case 2:
                scheduler.AddAtEnd();
                break;
            case 3:
                scheduler.AddAtPosition();
                break;
            case 4:
                scheduler.RemoveByTaskId();
                break;
            case 5:
                scheduler.ViewCurrentAndMoveNext();
                break;
            case 6:
                scheduler.DisplayAll();
                break;
            case 7:
                scheduler.SearchByPriority();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        ShowMenu();
    }
}

public class TaskMain
{
    public static void Start()
    {
        ITaskScheduler scheduler = new TaskSchedulerImpl();
        TaskMenu menu = new TaskMenu(scheduler);
        menu.ShowMenu();
    }
}

class TaskScheduler
{
    static void Main(string[] args)
    {
        TaskMain.Start();
    }
}
