public class Submission
{
    public int Id { get; private set; }
    public string Question { get; private set; }
    public string Answer { get; private set; }

    public Submission(int id, string question, string answer)
    {
        Id = id;
        Question = question;
        Answer = answer;
    }

    public override string ToString()
    {
        return $"Student {Id} - Q:{Question} - A:{Answer}";
    }
}