using System;

class Voting{
    //Main()
    static void Main(){
        int[] ages = new int[10]; //Array to store ages

        for(int i = 0; i < ages.Length; i++){
            Console.WriteLine("Enter age of student " + (i + 1) + ":- ");
            ages[i] = int.Parse(Console.ReadLine()); //User given age

            bool canVote = CanStudentVote(ages[i]); //Check voting eligibility
            Console.WriteLine("Can Vote:- " + canVote);
        }
    }

    //Method to check voting eligibility
    static bool CanStudentVote(int age){
        if(age < 0)
            return false;
        if(age >= 18)
            return true;
        return false;
    }
}
