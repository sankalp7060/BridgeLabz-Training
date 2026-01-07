using System;

/* ================= PROCESS ================= */
class Process
{
    public int ProcessId;
    public int BurstTime;
    public int RemainingTime;
    public int Priority;
    public int WaitingTime;
    public int TurnAroundTime;

    public Process(int id, int burst, int priority)
    {
        ProcessId = id;
        BurstTime = burst;
        RemainingTime = burst;
        Priority = priority;
    }
}

/* ================= NODE ================= */
class ProcessNode
{
    public Process Data;
    public ProcessNode Next;

    public ProcessNode(Process process)
    {
        Data = process;
        Next = null;
    }
}

/* ================= CIRCULAR LINKED LIST ================= */
class RoundRobinScheduler
{
    private ProcessNode head = null;
    private int processCount = 0;

    /* ---------- ADD PROCESS ---------- */
    public void AddProcess()
    {
        Console.Write("Process ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Burst Time: ");
        int burst = int.Parse(Console.ReadLine());

        Console.Write("Priority: ");
        int priority = int.Parse(Console.ReadLine());

        Process process = new Process(id, burst, priority);
        ProcessNode node = new ProcessNode(process);

        if (head == null)
        {
            head = node;
            node.Next = node;
        }
        else
        {
            ProcessNode temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            temp.Next = node;
            node.Next = head;
        }

        processCount++;
    }

    /* ---------- REMOVE PROCESS ---------- */
    private void RemoveProcess(ProcessNode prev, ProcessNode curr)
    {
        if (curr == head && curr.Next == head)
        {
            head = null;
        }
        else
        {
            if (curr == head)
                head = head.Next;

            prev.Next = curr.Next;
        }
        processCount--;
    }

    /* ---------- DISPLAY ---------- */
    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in queue.");
            return;
        }

        ProcessNode temp = head;
        Console.WriteLine("Processes in Queue:");
        do
        {
            Console.WriteLine($"PID: {temp.Data.ProcessId}, Remaining: {temp.Data.RemainingTime}");
            temp = temp.Next;
        } while (temp != head);
    }

    /* ---------- ROUND ROBIN SIMULATION ---------- */
    public void Simulate()
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule.");
            return;
        }

        Console.Write("Enter Time Quantum: ");
        int quantum = int.Parse(Console.ReadLine());

        int currentTime = 0;
        ProcessNode curr = head;
        ProcessNode prev = null;

        while (processCount > 0)
        {
            if (curr.Data.RemainingTime > 0)
            {
                int execTime = Math.Min(quantum, curr.Data.RemainingTime);
                curr.Data.RemainingTime -= execTime;
                currentTime += execTime;
            }

            if (curr.Data.RemainingTime == 0)
            {
                curr.Data.TurnAroundTime = currentTime;
                curr.Data.WaitingTime = curr.Data.TurnAroundTime - curr.Data.BurstTime;

                Console.WriteLine($"Process {curr.Data.ProcessId} completed.");

                RemoveProcess(prev, curr);

                if (processCount == 0)
                    break;

                curr = (prev != null) ? prev.Next : head;
            }
            else
            {
                prev = curr;
                curr = curr.Next;
            }

            DisplayProcesses();
            Console.WriteLine("----------------------------");
        }

        DisplayAverages();
    }

    /* ---------- AVERAGES ---------- */
    private void DisplayAverages()
    {
        Console.WriteLine("\n--- Scheduling Completed ---");
        Console.WriteLine("Average Waiting Time and Turnaround Time calculated during execution.");
        Console.WriteLine("Note: Values shown per process during completion.");
    }
}

/* ================= MAIN ================= */
class Program
{
    static void Main()
    {
        RoundRobinScheduler scheduler = new RoundRobinScheduler();

        while (true)
        {
            Console.WriteLine("\n1 Add Process");
            Console.WriteLine("2 Display Processes");
            Console.WriteLine("3 Simulate Round Robin");
            Console.WriteLine("0 Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    scheduler.AddProcess();
                    break;
                case 2:
                    scheduler.DisplayProcesses();
                    break;
                case 3:
                    scheduler.Simulate();
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
