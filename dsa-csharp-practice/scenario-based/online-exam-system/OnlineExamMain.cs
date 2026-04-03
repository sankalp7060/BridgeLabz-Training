using System;

sealed class OnlineExamMain
{
    public static void Start()
    {
        OnlineExamUtility exam = new OnlineExamUtility();

        exam.SubmitAnswer(101, "Q1", "Answer1");
        exam.SubmitAnswer(102, "Q1", "Answer2");
        exam.SubmitAnswer(101, "Q2", "Answer3");

        exam.SubmitAnswer(101, "Q1", "Answer1 Again");

        exam.DisplayPendingSubmissions();

        exam.UndoLastSubmission();

        exam.DisplayPendingSubmissions();

        Console.WriteLine("Check duplicate Q1 for 101: " + exam.IsDuplicateSubmission(101, "Q1"));
        Console.WriteLine("Check duplicate Q2 for 101: " + exam.IsDuplicateSubmission(101, "Q2"));
    }
}
