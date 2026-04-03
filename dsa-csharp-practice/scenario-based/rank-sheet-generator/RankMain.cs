using System;
using System.Collections.Generic;

sealed class RankMain
{
    public static void Start()
    {
        IRankGenerator rankGenerator = new MergeSortService();

        // Simulating sorted district lists
        List<Student> students = new List<Student>()
        {
            new Student("Aman", 90, "Delhi"),
            new Student("Riya", 85, "Delhi"),
            new Student("Kunal", 92, "Mumbai"),
            new Student("Pooja", 85, "Mumbai"),
            new Student("Rahul", 88, "Chennai"),
            new Student("Neha", 92, "Chennai"),
        };

        Console.WriteLine("\n=== State Rank List ===\n");

        var result = rankGenerator.GenerateRankList(students);

        int rank = 1;

        foreach (var student in result)
        {
            Console.WriteLine(
                $"Rank {rank++} -> {student.Name} | {student.Marks} | {student.District}"
            );
        }

        Console.ReadLine();
    }
}
