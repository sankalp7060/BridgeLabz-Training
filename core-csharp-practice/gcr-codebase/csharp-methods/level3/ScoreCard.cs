using System; //Using System namespace

class StudentMarks{
    //Main() 
    static void Main(){
        Console.WriteLine("Enter number of students:- "); //Input
        int students = int.Parse(Console.ReadLine()); //Reading input

        int[,] scores = GenerateScores(students); //Generating scores
        double[,] results = CalculateResults(scores); //Calculating totals
        DisplayScoreCard(scores, results); //Displaying scorecard
    }

    //Method to generate scores
    static int[,] GenerateScores(int students){
        int[,] scores = new int[students,3]; //PCM scores
        Random random = new Random(); //Random object

        for(int i=0;i<students;i++) //Loop
        {
            scores[i,0] = random.Next(10,99); //Physics
            scores[i,1] = random.Next(10,99); //Chemistry
            scores[i,2] = random.Next(10,99); //Maths
        }
        return scores; //Returning scores
    }

    //Method to calculate results
    static double[,] CalculateResults(int[,] scores){
        double[,] result = new double[scores.GetLength(0),3]; //Total, Avg, Percent

        for(int i=0;i<scores.GetLength(0);i++){
            double total = scores[i,0]+scores[i,1]+scores[i,2]; //Total
            result[i,0] = total; //Storing total
            result[i,1] = Math.Round(total/3,2); //Average
            result[i,2] = Math.Round((total/300)*100,2); //Percentage
        }
        return result; //Returning result
    }

    //Method to display scorecard
    static void DisplayScoreCard(int[,] scores, double[,] result){
        Console.WriteLine("P\tC\tM\tTotal\tAvg\t%"); //Header

        for(int i=0;i<scores.GetLength(0);i++) //Loop
        {
            Console.WriteLine(scores[i,0]+"\t"+scores[i,1]+"\t"+scores[i,2]+"\t"+
                              result[i,0]+"\t"+result[i,1]+"\t"+result[i,2]); //Printing row
        }
    }
}
