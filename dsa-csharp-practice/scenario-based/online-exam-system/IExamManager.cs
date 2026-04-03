public interface IExamManager
{
    void SubmitAnswer(int id, string question, string answer);
    void DisplayPendingSubmissions();
    void UndoLastSubmission();
    bool IsDuplicateSubmission(int id, string question);
}
