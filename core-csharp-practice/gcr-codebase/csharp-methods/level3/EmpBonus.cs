using System; 

class EmpBonus {
    //Main() 
    static void Main(){
        double[,] employees = GenerateEmployeeData(); //Generating salary & service
        double[,] updated = CalculateBonus(employees); //Calculating bonus
        DisplaySummary(employees, updated); //Displaying summary
    }

    //Method to generate salary & service
    static double[,] GenerateEmployeeData(){
        double[,] data = new double[10,2]; //2D array
        Random random = new Random(); //Random object

        for(int i=0;i<10;i++) {
            data[i,0] = random.Next(10000,99999); //Salary
            data[i,1] = random.Next(1,10); //Years of service
        }
        return data; //Returning array
    }

    //Method to calculate bonus
    static double[,] CalculateBonus(double[,] data){
        double[,] result = new double[10,2]; //New salary & bonus

        for(int i=0;i<10;i++) //Loop
        {
            double salary = data[i,0]; //Old salary
            double years = data[i,1]; //Service years
            double bonus = years > 5 ? salary * 0.05 : salary * 0.02; //Bonus logic
            result[i,0] = salary + bonus; //New salary
            result[i,1] = bonus; //Bonus
        }
        return result; //Returning updated data
    }

    //Method to display summary
    static void DisplaySummary(double[,] oldData, double[,] newData){
        Console.WriteLine("OldSalary\tNewSalary\tBonus"); //Header

        for(int i=0;i<10;i++) //Loop
        {
            Console.WriteLine(oldData[i,0]+"\t"+newData[i,0]+"\t"+newData[i,1]); //Displaying row
        }
    }
}
