using System;
using System.Collections.Generic;

// Abstract Job Role Base Class
public abstract class JobRole
{
    public string CandidateName { get; set; }

    protected JobRole(string name)
    {
        CandidateName = name;
    }

    public abstract void DisplayRole();
}

// Software Engineer Role
public class SoftwareEngineer : JobRole
{
    public int CodingScore { get; set; }

    public SoftwareEngineer(string name, int score)
        : base(name)
    {
        CodingScore = score;
    }

    public override void DisplayRole()
    {
        Console.WriteLine($"Software Engineer: {CandidateName}, Coding Score: {CodingScore}");
    }
}

// Data Scientist Role
public class DataScientist : JobRole
{
    public int MLScore { get; set; }

    public DataScientist(string name, int score)
        : base(name)
    {
        MLScore = score;
    }

    public override void DisplayRole()
    {
        Console.WriteLine($"Data Scientist: {CandidateName}, ML Score: {MLScore}");
    }
}

// Generic Resume Processor
public class Resume<T>
    where T : JobRole
{
    private List<T> candidates = new List<T>();

    public void AddResume(T candidate)
    {
        candidates.Add(candidate);
        Console.WriteLine($"{candidate.CandidateName} added to screening list");
    }

    public void ProcessResumes()
    {
        Console.WriteLine("\n--- Resume Screening ---");
        foreach (var candidate in candidates)
        {
            candidate.DisplayRole();
        }
    }
}

// Generic Screening Utility
public static class ResumeAnalyzer
{
    public static void ValidateResume<T>(T candidate)
        where T : JobRole
    {
        Console.WriteLine($"Resume validated for {candidate.CandidateName}");
    }
}

// Main Program
class ResumeScreening
{
    static void Main()
    {
        Resume<SoftwareEngineer> seResumes = new Resume<SoftwareEngineer>();
        Resume<DataScientist> dsResumes = new Resume<DataScientist>();

        SoftwareEngineer se = new SoftwareEngineer("Amit", 85);
        DataScientist ds = new DataScientist("Riya", 90);

        ResumeAnalyzer.ValidateResume(se);
        ResumeAnalyzer.ValidateResume(ds);

        seResumes.AddResume(se);
        dsResumes.AddResume(ds);

        seResumes.ProcessResumes();
        dsResumes.ProcessResumes();
    }
}
