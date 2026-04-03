using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class TodoAttribute : Attribute
{
    public string Task;
    public string AssignedTo;
    public string Priority = "MEDIUM";

    public TodoAttribute(string task, string assignedTo)
    {
        Task = task;
        AssignedTo = assignedTo;
    }
}

class Project
{
    [Todo("Add login", "Amit")]
    public void Login() { }

    [Todo("Fix payment bug", "Rahul")]
    public void Payment() { }
}

class TodoAttributeProgram
{
    static void Main()
    {
        foreach (MethodInfo m in typeof(Project).GetMethods())
        {
            var todo = (TodoAttribute)Attribute.GetCustomAttribute(m, typeof(TodoAttribute));

            if (todo != null)
            {
                Console.WriteLine($"{todo.Task} - {todo.AssignedTo} - {todo.Priority}");
            }
        }
    }
}
