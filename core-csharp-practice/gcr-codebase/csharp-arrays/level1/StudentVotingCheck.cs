using System;

class StudentVotingCheck{
    //Main()
    static void Main(){
        // Integer array to store age of 10 students
        int[] ages = new int[10];
        Console.WriteLine("Enter age of 10 students:");

        // Taking user input for 10 students
        for (int i = 0; i < ages.Length; i++){
            Console.Write($"Enter age of student {i + 1}: ");
            ages[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("\nVoting Eligibility Result:");

        // Check voting eligibility using loop
        for (int i = 0; i < ages.Length; i++){
            // Check for invalid age
            if (ages[i] < 0){
                Console.WriteLine($"Invalid age entered: {ages[i]}");
            }
            // Student who are eligible to vote
            else if (ages[i] >= 18){
                Console.WriteLine($"The student with age {ages[i]} can vote");
            }
            // Students below 18 cannot vote
            else{
                Console.WriteLine($"The student with age {ages[i]} cannot vote");
            }
        }
    }
}
