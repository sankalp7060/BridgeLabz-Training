using System; //Using System namespace

class OTP{
    //Main() method
    static void Main(){
        int[] otpArray = new int[10]; //Array to store 10 OTPs

        for(int index = 0; index < otpArray.Length; index++) //Loop to generate OTPs
        {
            otpArray[index] = GenerateOTP(); //Generating OTP
            Console.WriteLine("Generated OTP : " + otpArray[index]); //Displaying OTP
        }

        bool isUnique = AreOTPsUnique(otpArray); //Checking uniqueness

        Console.WriteLine("Are all OTPs unique : " + isUnique); //Displaying result
    }

    //Method to generate 6-digit OTP
    static int GenerateOTP(){
        Random random = new Random(); // Creating Random object
        int otp = random.Next(100000, 1000000); // Generating 6-digit OTP
        return otp; //Returning OTP
    }

    //Method to check uniqueness of OTPs
    static bool AreOTPsUnique(int[] otps){
        for(int i = 0; i < otps.Length; i++){
            for(int j = i + 1; j < otps.Length; j++) {
                if(otps[i] == otps[j]) {//Checking duplicate
                    return false; //Returning false if duplicate found
                }
            }
        }
        return true; //Returning true if all unique
    }
}
