using System;

class TextState
{
    public string Content;
    public TextState Prev;
    public TextState Next;

    public TextState(string content)
    {
        Content = content;
        Prev = null;
        Next = null;
    }
}

class TextEditor
{
    private TextState head;
    private TextState tail;
    private TextState current;
    private int size;
    private const int MAX_HISTORY = 10;

    // Add new text state
    public void AddState(string content)
    {
        TextState newState = new TextState(content);

        // If undo was used, remove redo states
        if (current != null && current.Next != null)
        {
            current.Next.Prev = null;
            current.Next = null;
            tail = current;
        }

        if (head == null)
        {
            head = tail = current = newState;
            size = 1;
            return;
        }

        tail.Next = newState;
        newState.Prev = tail;
        tail = newState;
        current = newState;
        size++;

        // Limit history size
        if (size > MAX_HISTORY)
        {
            head = head.Next;
            head.Prev = null;
            size--;
        }
    }

    // Undo operation
    public void Undo()
    {
        if (current == null || current.Prev == null)
        {
            Console.WriteLine("Nothing to undo.");
            return;
        }

        current = current.Prev;
        Console.WriteLine("Undo performed.");
    }

    // Redo operation
    public void Redo()
    {
        if (current == null || current.Next == null)
        {
            Console.WriteLine("Nothing to redo.");
            return;
        }

        current = current.Next;
        Console.WriteLine("Redo performed.");
    }

    // Display current text
    public void DisplayCurrentState()
    {
        if (current == null)
        {
            Console.WriteLine("Editor is empty.");
            return;
        }

        Console.WriteLine("Current Text:");
        Console.WriteLine(current.Content);
    }
}

class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();

        editor.AddState("Hello");
        editor.AddState("Hello World");
        editor.AddState("Hello World!");
        editor.DisplayCurrentState();

        editor.Undo();
        editor.DisplayCurrentState();

        editor.Undo();
        editor.DisplayCurrentState();

        editor.Redo();
        editor.DisplayCurrentState();

        editor.AddState("Hello World!!!");
        editor.DisplayCurrentState();

        editor.Redo(); // Should not redo
    }
}
