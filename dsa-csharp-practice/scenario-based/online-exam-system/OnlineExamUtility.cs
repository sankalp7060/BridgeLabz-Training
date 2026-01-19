using System;

public class OnlineExamUtility : IExamManager
{
    private CustomQueue submission = new CustomQueue();
    private CustomStack history = new CustomStack();
    private CustomMap map = new CustomMap();

    public void SubmitAnswer(int id, string question, string answer)
    {
        if (map.Contains(id, question))
        {
            Console.WriteLine($"Duplicate submission detected for {id}, Question {question}");
            return;
        }
        Submission sub = new Submission(id, question, answer);
        submission.Enqueue(sub);
        history.Push(sub);
        map.Put(id, question);
        Console.WriteLine($"Submission Accepted: {sub}");
    }

    public void DisplayPendingSubmissions()
    {
        Console.WriteLine("Pending Submissions:");
        submission.Display();
    }

    public void UndoLastSubmission()
    {
        Submission last = history.Pop();
        if (last == null)
        {
            Console.WriteLine("No submission to undo");
            return;
        }
        CustomQueue tempQueue = new CustomQueue();
        while (!submission.IsEmpty())
        {
            Submission s = submission.Dequeue();
            if (s != last)
                tempQueue.Enqueue(s);
        }
        submission = tempQueue;
        map.Remove(last.Id, last.Question);
        Console.WriteLine($"Last submission undone: {last}");
    }

    public bool IsDuplicateSubmission(int id, string question)
    {
        return map.Contains(id, question);
    }
}
