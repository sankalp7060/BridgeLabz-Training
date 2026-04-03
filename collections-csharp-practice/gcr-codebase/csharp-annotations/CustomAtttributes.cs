using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class TaskInfoAttribute : Attribute
{
    public string Priority { get; set; }
    public string AssignedTo { get; set; }

    public TaskInfoAttribute(string priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

class TaskManager
{
    [TaskInfo("HIGH", "Sankalp")]
    public void ProcessTask()
    {
        Console.WriteLine("Task Processing...");
    }
}

class CustomAtttributes
{
    static void Main()
    {
        MethodInfo method = typeof(TaskManager).GetMethod("ProcessTask");

        TaskInfoAttribute attr = (TaskInfoAttribute)
            Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));

        Console.WriteLine(attr.Priority);
        Console.WriteLine(attr.AssignedTo);
    }
}
