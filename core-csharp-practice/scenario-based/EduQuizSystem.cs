using System;

class EduQuiz
{
    // ================= STORAGE =================
    private static int studentCount = 0;
    private static string[] studentIds = new string[10];
    private static string[] studentNames = new string[10];
    private static string[] studentPasswords = new string[10];
    private static string loggedInStudentId = null;

    private const string teacherId = "teacher";
    private const string teacherPass = "teach123";

    // ================= QUESTIONS =================
    private static int totalQuestions = 30;
    private static string[] questions = new string[100];
    private static string[,] options = new string[100, 4];
    private static int[] correctAnswers = new int[100];

    // ================= QUIZZES =================
    private static int quizCount = 0;
    private static string[] quizTitles = new string[20];
    private static int[,] quizQuestions = new int[20, 50];
    private static int[] quizQuestionCount = new int[20];

    // ================= QUIZ HISTORY =================
    private static int historyCount = 0;
    private static string[] historyStudent = new string[100];
    private static string[] historyQuizTitle = new string[100];
    private static int[] historyScore = new int[100];

    // ================= MAIN =================
    static void Main()
    {
        InitializeDefaultQuestions();

        while (true)
        {
            Console.WriteLine(
                "\n========================================================================================================="
            );
            Console.WriteLine("                                       WHO ARE YOU?");
            Console.WriteLine(
                "=========================================================================================================\n"
            );
            Console.WriteLine("                                       1. Student");
            Console.WriteLine("                                       2. Teacher");
            Console.WriteLine("                                       3. Exit\n");
            Console.Write("Select option: ");

            if (!int.TryParse(Console.ReadLine(), out int role))
                continue;

            if (role == 1)
                StudentFlow();
            else if (role == 2)
                TeacherFlow();
            else if (role == 3)
            {
                Console.WriteLine("Goodbye!");
                return;
            }
        }
    }

    // ================= STUDENT FLOW =================
    private static void StudentFlow()
    {
        Console.WriteLine("\n1. Register\n2. Login");
        Console.Write("Select option: ");
        if (!int.TryParse(Console.ReadLine(), out int choice))
            return;

        if (choice == 1)
            RegisterStudent();
        else if (choice == 2)
        {
            if (LoginStudent())
                StudentMenu();
        }
    }

    private static void RegisterStudent()
    {
        if (studentCount == studentIds.Length)
        {
            Console.WriteLine("Student storage full.");
            return;
        }

        Console.Write("Student ID: ");
        string id = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        for (int i = 0; i < studentCount; i++)
        {
            if (studentIds[i] == id)
            {
                Console.WriteLine("Student ID already exists.");
                return;
            }
        }

        Console.Write("Name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name.");
            return;
        }

        Console.Write("Password: ");
        string pass = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(pass))
        {
            Console.WriteLine("Invalid password.");
            return;
        }

        studentIds[studentCount] = id;
        studentNames[studentCount] = name;
        studentPasswords[studentCount] = pass;
        studentCount++;

        Console.WriteLine("Registration successful.");
    }

    private static bool LoginStudent()
    {
        Console.Write("Student ID: ");
        string id = Console.ReadLine();
        Console.Write("Password: ");
        string pass = Console.ReadLine();

        for (int i = 0; i < studentCount; i++)
        {
            if (studentIds[i] == id && studentPasswords[i] == pass)
            {
                loggedInStudentId = id;
                Console.WriteLine($"Welcome {studentNames[i]}!");
                return true;
            }
        }

        Console.WriteLine("Invalid credentials.");
        return false;
    }

    private static void StudentMenu()
    {
        while (true)
        {
            ShowStudentMenu();
            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1:
                    GiveQuiz();
                    break;
                case 2:
                    ViewQuizHistory();
                    break;
                case 3:
                    loggedInStudentId = null;
                    Console.Clear();
                    return;
            }
        }
    }

    private static void ShowStudentMenu()
    {
        Console.WriteLine(
            "\n========================================================================================================="
        );
        Console.WriteLine("                                       STUDENT MENU");
        Console.WriteLine(
            "=========================================================================================================\n"
        );
        Console.WriteLine("                                       1. Take Quiz");
        Console.WriteLine("                                       2. View Quiz History");
        Console.WriteLine("                                       3. Logout\n");
        Console.Write("Select option: ");
    }

    // ================= TEACHER FLOW =================
    private static void TeacherFlow()
    {
        Console.Write("Teacher ID: ");
        string id = Console.ReadLine();
        Console.Write("Password: ");
        string pass = Console.ReadLine();

        if (id != teacherId || pass != teacherPass)
        {
            Console.WriteLine("Unauthorized access.");
            return;
        }

        Console.WriteLine("Login successful!");

        while (true)
        {
            ShowTeacherMenu();
            if (!int.TryParse(Console.ReadLine(), out int choice))
                continue;

            switch (choice)
            {
                case 1:
                    AddQuestion();
                    break;
                case 2:
                    MakeQuiz();
                    break;
                case 3:
                    ViewQuizResults();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Logged out successfully.");
                    return;
            }
        }
    }

    private static void ShowTeacherMenu()
    {
        Console.WriteLine(
            "\n========================================================================================================="
        );
        Console.WriteLine("                                       TEACHER MENU");
        Console.WriteLine(
            "=========================================================================================================\n"
        );
        Console.WriteLine("                                       1. Add Question");
        Console.WriteLine("                                       2. Make Quiz");
        Console.WriteLine("                                       3. View Quiz Results");
        Console.WriteLine("                                       4. Logout\n");
        Console.Write("Select option: ");
    }

    // ================= TEACHER ACTIONS =================
    private static void AddQuestion()
    {
        if (totalQuestions >= questions.Length)
        {
            Console.WriteLine("Cannot add more questions.");
            return;
        }

        Console.Write("Question: ");
        string q = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(q))
        {
            Console.WriteLine("Question cannot be empty.");
            return;
        }

        string[] opts = new string[4];
        for (int i = 0; i < 4; i++)
        {
            while (true)
            {
                Console.Write($"Option {i + 1}: ");
                opts[i] = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(opts[i]))
                    break;
                Console.WriteLine("Option cannot be empty.");
            }
        }

        Console.Write("Correct Answer (1-4): ");
        if (!int.TryParse(Console.ReadLine(), out int ans) || ans < 1 || ans > 4)
        {
            Console.WriteLine("Invalid correct answer.");
            return;
        }

        questions[totalQuestions] = q;
        for (int i = 0; i < 4; i++)
            options[totalQuestions, i] = opts[i];
        correctAnswers[totalQuestions] = ans - 1;

        totalQuestions++;
        Console.WriteLine("Question added successfully.\n");
    }

    private static void MakeQuiz()
    {
        if (quizCount >= quizTitles.Length)
        {
            Console.WriteLine("Cannot create more quizzes.");
            return;
        }

        Console.Write("Quiz Title: ");
        string title = Console.ReadLine().Trim();
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Quiz title cannot be empty.");
            return;
        }

        // Check for duplicate quiz titles
        for (int i = 0; i < quizCount; i++)
        {
            if (quizTitles[i] == title)
            {
                Console.WriteLine("Quiz with this title already exists.");
                return;
            }
        }

        quizTitles[quizCount] = title;

        Console.Write("\nHow many questions do you want in this quiz: ");
        if (
            !int.TryParse(Console.ReadLine(), out int numQuestions)
            || numQuestions <= 0
            || numQuestions > totalQuestions
        )
        {
            Console.WriteLine($"Invalid number. Must be between 1 and {totalQuestions}.");
            return;
        }

        // Show selection options
        Console.WriteLine("\nHow would you like to select questions?");
        Console.WriteLine("1. Manually select questions");
        Console.WriteLine("2. Randomly select questions");

        if (numQuestions == totalQuestions) // Only show if teacher wants all questions
        {
            Console.WriteLine("3. Add all 30 questions");
        }

        Console.Write("\nSelect option: ");
        if (
            !int.TryParse(Console.ReadLine(), out int selectionOption)
            || selectionOption < 1
            || selectionOption > (numQuestions == totalQuestions ? 3 : 2)
        )
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        quizQuestionCount[quizCount] = numQuestions;

        if (selectionOption == 1) // Manual selection
        {
            Console.WriteLine("\nAvailable questions:\n");

            // Show available questions with their actual content
            for (int i = 0; i < totalQuestions; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i]}");
                Console.WriteLine($"   A. {options[i, 0]}");
                Console.WriteLine($"   B. {options[i, 1]}");
                Console.WriteLine($"   C. {options[i, 2]}");
                Console.WriteLine($"   D. {options[i, 3]}");
                Console.WriteLine();
            }

            for (int i = 0; i < numQuestions; i++)
            {
                while (true)
                {
                    Console.Write($"Enter Question number for question {i + 1}: ");
                    if (
                        int.TryParse(Console.ReadLine(), out int qNum)
                        && qNum >= 1
                        && qNum <= totalQuestions
                    )
                    {
                        // Check if question is already added to this quiz
                        bool alreadyAdded = false;
                        for (int j = 0; j < i; j++)
                        {
                            if (quizQuestions[quizCount, j] == qNum - 1)
                            {
                                alreadyAdded = true;
                                Console.WriteLine(
                                    "This question is already in the quiz. Select another."
                                );
                                break;
                            }
                        }

                        if (!alreadyAdded)
                        {
                            quizQuestions[quizCount, i] = qNum - 1;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Invalid question number. Must be between 1 and {totalQuestions}."
                        );
                    }
                }
            }
        }
        else if (selectionOption == 2) // Random selection
        {
            Console.WriteLine("\nRandomly selecting questions...");

            // Create an array of all available question indices
            int[] allQuestionIndices = new int[totalQuestions];
            for (int i = 0; i < totalQuestions; i++)
            {
                allQuestionIndices[i] = i;
            }

            // Shuffle the array (Fisher-Yates shuffle)
            Random rand = new Random();
            for (int i = totalQuestions - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                // Swap
                int temp = allQuestionIndices[i];
                allQuestionIndices[i] = allQuestionIndices[j];
                allQuestionIndices[j] = temp;
            }

            // Take first 'numQuestions' indices
            for (int i = 0; i < numQuestions; i++)
            {
                quizQuestions[quizCount, i] = allQuestionIndices[i];
            }

            // Show which questions were selected
            Console.WriteLine($"Selected {numQuestions} random questions:");
            for (int i = 0; i < numQuestions; i++)
            {
                int qIndex = quizQuestions[quizCount, i];
                Console.WriteLine($"{i + 1}. Question {qIndex + 1}: {questions[qIndex]}");
            }
            Console.WriteLine();
        }
        else if (selectionOption == 3) // Add all 30 questions (only shown when numQuestions == 30)
        {
            Console.WriteLine("\nAdding all 30 questions to the quiz...");

            // Add all question indices in order
            for (int i = 0; i < totalQuestions; i++)
            {
                quizQuestions[quizCount, i] = i;
            }

            Console.WriteLine("All 30 questions have been added to the quiz.\n");
        }

        quizCount++;
        Console.WriteLine($"Quiz '{title}' created successfully with {numQuestions} questions.\n");
    }

    private static void ViewQuizResults()
    {
        if (historyCount == 0)
        {
            Console.WriteLine("No quiz results yet.");
            return;
        }

        Console.WriteLine("\n=== QUIZ RESULTS ===");
        for (int i = 0; i < historyCount; i++)
        {
            Console.WriteLine(
                $"{i + 1}. Student: {historyStudent[i]} | Quiz: {historyQuizTitle[i]} | Score: {historyScore[i]}%"
            );
        }
        Console.WriteLine();
    }

    // ================= STUDENT ACTIONS =================
    private static void GiveQuiz()
    {
        if (quizCount == 0)
        {
            Console.WriteLine("No active quizzes available.");
            return;
        }

        Console.WriteLine("\nAvailable Quizzes:");
        for (int i = 0; i < quizCount; i++)
        {
            Console.WriteLine($"{i + 1}. {quizTitles[i]} ({quizQuestionCount[i]} questions)");
        }

        Console.Write("\nSelect Quiz Number: ");
        if (
            !int.TryParse(Console.ReadLine(), out int quizNum)
            || quizNum < 1
            || quizNum > quizCount
        )
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        quizNum -= 1;

        if (quizQuestionCount[quizNum] == 0)
        {
            Console.WriteLine("This quiz has no questions.");
            return;
        }

        int score = 0;
        Console.WriteLine($"\nStarting Quiz: {quizTitles[quizNum]}");
        Console.WriteLine("--------------------------------------------------");

        for (int i = 0; i < quizQuestionCount[quizNum]; i++)
        {
            int qIndex = quizQuestions[quizNum, i];

            Console.WriteLine($"\nQuestion {i + 1}: {questions[qIndex]}");
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"   {j + 1}. {options[qIndex, j]}");
            }

            Console.Write("Your Answer (1-4): ");
            if (
                int.TryParse(Console.ReadLine().Trim(), out int userAnswer)
                && userAnswer >= 1
                && userAnswer <= 4
            )
            {
                if (userAnswer - 1 == correctAnswers[qIndex])
                {
                    Console.WriteLine("✓ Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine(
                        $"✗ Incorrect! Correct answer was: {correctAnswers[qIndex] + 1}"
                    );
                }
            }
            else
            {
                Console.WriteLine(
                    $"Invalid input! Correct answer was: {correctAnswers[qIndex] + 1}"
                );
            }
        }

        int percent = (score * 100) / quizQuestionCount[quizNum];
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine(
            $"Quiz Completed! Score: {score}/{quizQuestionCount[quizNum]} = {percent}%"
        );
        Console.WriteLine($"Result: {(percent >= 50 ? "PASS" : "FAIL")}\n");

        // Save history
        historyStudent[historyCount] = loggedInStudentId;
        historyQuizTitle[historyCount] = quizTitles[quizNum];
        historyScore[historyCount] = percent;
        historyCount++;

        // Show student's name
        string studentName = "Unknown";
        for (int i = 0; i < studentCount; i++)
        {
            if (studentIds[i] == loggedInStudentId)
            {
                studentName = studentNames[i];
                break;
            }
        }
        Console.WriteLine($"Well done, {studentName}!");
    }

    private static void ViewQuizHistory()
    {
        if (loggedInStudentId == null)
        {
            Console.WriteLine("Not logged in.");
            return;
        }

        bool found = false;
        Console.WriteLine("\n=== YOUR QUIZ HISTORY ===");
        for (int i = 0; i < historyCount; i++)
        {
            if (historyStudent[i] == loggedInStudentId)
            {
                Console.WriteLine(
                    $"{i + 1}. Quiz: {historyQuizTitle[i]} | Score: {historyScore[i]}%"
                );
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No quiz history found.");
        Console.WriteLine();
    }

    //Default questions
    private static void InitializeDefaultQuestions()
    {
        // Question 1
        questions[0] = "What is the default access modifier for class members in C#?";
        options[0, 0] = "private";
        options[0, 1] = "public";
        options[0, 2] = "protected";
        options[0, 3] = "internal";
        correctAnswers[0] = 0; // private

        // Question 2
        questions[1] = "Which keyword is used to create an object in C#?";
        options[1, 0] = "new";
        options[1, 1] = "create";
        options[1, 2] = "object";
        options[1, 3] = "make";
        correctAnswers[1] = 0; // new

        // Question 3
        questions[2] = "What is the base class for all classes in C#?";
        options[2, 0] = "System.Object";
        options[2, 1] = "System.Base";
        options[2, 2] = "System.Class";
        options[2, 3] = "System.Root";
        correctAnswers[2] = 0; // System.Object

        // Question 4
        questions[3] = "Which of these is a value type in C#?";
        options[3, 0] = "int";
        options[3, 1] = "string";
        options[3, 2] = "array";
        options[3, 3] = "class";
        correctAnswers[3] = 0; // int

        // Question 5
        questions[4] = "What does 'void' indicate in a method declaration?";
        options[4, 0] = "Method returns any value";
        options[4, 1] = "Method accepts no parameters";
        options[4, 2] = "Method returns no value";
        options[4, 3] = "Method is empty";
        correctAnswers[4] = 2; // Method returns no value

        // Question 6
        questions[5] = "Which loop guarantees at least one execution?";
        options[5, 0] = "while";
        options[5, 1] = "do-while";
        options[5, 2] = "for";
        options[5, 3] = "foreach";
        correctAnswers[5] = 1; // do-while

        // Question 7
        questions[6] = "What is the purpose of 'break' statement?";
        options[6, 0] = "Skip current iteration";
        options[6, 1] = "Exit loop or switch";
        options[6, 2] = "Stop program";
        options[6, 3] = "Pause execution";
        correctAnswers[6] = 1; // Exit loop or switch

        // Question 8
        questions[7] = "Which collection stores key-value pairs?";
        options[7, 0] = "List";
        options[7, 1] = "Dictionary";
        options[7, 2] = "Array";
        options[7, 3] = "Queue";
        correctAnswers[7] = 1; // Dictionary

        // Question 9
        questions[8] = "What does 'static' mean in C#?";
        options[8, 0] = "Cannot be changed";
        options[8, 1] = "Belongs to type, not instance";
        options[8, 2] = "Read-only";
        options[8, 3] = "Thread-safe";
        correctAnswers[8] = 1; // Belongs to type, not instance

        // Question 10
        questions[9] = "Which access modifier is most restrictive?";
        options[9, 0] = "protected";
        options[9, 1] = "private";
        options[9, 2] = "internal";
        options[9, 3] = "public";
        correctAnswers[9] = 1; // private

        // Question 11
        questions[10] = "What is polymorphism?";
        options[10, 0] = "Hiding implementation";
        options[10, 1] = "Same interface, different implementation";
        options[10, 2] = "Creating objects";
        options[10, 3] = "Memory management";
        correctAnswers[10] = 1; // Same interface, different implementation

        // Question 12
        questions[11] = "Which is NOT a C# access modifier?";
        options[11, 0] = "private";
        options[11, 1] = "global";
        options[11, 2] = "protected";
        options[11, 3] = "public";
        correctAnswers[11] = 1; // global

        // Question 13
        questions[12] = "What is an interface?";
        options[12, 0] = "Base class";
        options[12, 1] = "Method collection";
        options[12, 2] = "Data structure";
        options[12, 3] = "Contract without implementation";
        correctAnswers[12] = 3; // Contract without implementation

        // Question 14
        questions[13] = "What is boxing?";
        options[13, 0] = "Converting reference type to value type";
        options[13, 1] = "Converting value type to reference type";
        options[13, 2] = "Wrapping objects";
        options[13, 3] = "Memory allocation";
        correctAnswers[13] = 1; // Converting value type to reference type

        // Question 15
        questions[14] = "Which is used for exception handling?";
        options[14, 0] = "if-else";
        options[14, 1] = "try-catch";
        options[14, 2] = "switch-case";
        options[14, 3] = "for-each";
        correctAnswers[14] = 1; // try-catch

        // Question 16
        questions[15] = "What does 'readonly' mean?";
        options[15, 0] = "Cannot be read";
        options[15, 1] = "Can be set only in constructor";
        options[15, 2] = "Always null";
        options[15, 3] = "Static value";
        correctAnswers[15] = 1; // Can be set only in constructor

        // Question 17
        questions[16] = "Which is a reference type?";
        options[16, 0] = "int";
        options[16, 1] = "class";
        options[16, 2] = "double";
        options[16, 3] = "bool";
        correctAnswers[16] = 1; // class

        // Question 18
        questions[17] = "What is method overloading?";
        options[17, 0] = "Different name, same parameters";
        options[17, 1] = "Same name in different classes";
        options[17, 2] = "Method with many lines";
        options[17, 3] = "Same name, different parameters";
        correctAnswers[17] = 3; // Same name, different parameters

        // Question 19
        questions[18] = "Which is a floating-point type?";
        options[18, 0] = "int";
        options[18, 1] = "float";
        options[18, 2] = "long";
        options[18, 3] = "decimal";
        correctAnswers[18] = 1; // float

        // Question 20
        questions[19] = "What is the 'Main' method?";
        options[19, 0] = "Primary method";
        options[19, 1] = "Program entry point";
        options[19, 2] = "Main class constructor";
        options[19, 3] = "Base method";
        correctAnswers[19] = 1; // Program entry point

        // Question 21
        questions[20] = "What is inheritance?";
        options[20, 0] = "Creating methods";
        options[20, 1] = "Data hiding";
        options[20, 2] = "Deriving class from base class";
        options[20, 3] = "Memory inheritance";
        correctAnswers[20] = 2; // Deriving class from base class

        // Question 22
        questions[21] = "Which is a conditional statement?";
        options[21, 0] = "for";
        options[21, 1] = "if";
        options[21, 2] = "using";
        options[21, 3] = "namespace";
        correctAnswers[21] = 1; // if

        // Question 23
        questions[22] = "What is a constructor?";
        options[22, 0] = "Destroys object";
        options[22, 1] = "Static method";
        options[22, 2] = "Property setter";
        options[22, 3] = "Initializes object";
        correctAnswers[22] = 3; // Initializes object

        // Question 24
        questions[23] = "What is an abstract class?";
        options[23, 0] = "Must be instantiated";
        options[23, 1] = "Cannot be instantiated";
        options[23, 2] = "Final class";
        options[23, 3] = "Static class";
        correctAnswers[23] = 1; // Cannot be instantiated

        // Question 25
        questions[24] = "What is the 'using' directive for?";
        options[24, 0] = "Create objects";
        options[24, 1] = "Import namespaces";
        options[24, 2] = "Dispose objects";
        options[24, 3] = "Loop through items";
        correctAnswers[24] = 1; // Import namespaces

        // Question 26
        questions[25] = "What is encapsulation?";
        options[25, 0] = "Creating classes";
        options[25, 1] = "Bundling data with methods";
        options[25, 2] = "Memory management";
        options[25, 3] = "Inheritance feature";
        correctAnswers[25] = 1; // Bundling data with methods

        // Question 27
        questions[26] = "Which is a logical operator?";
        options[26, 0] = "+";
        options[26, 1] = "&&";
        options[26, 2] = "=";
        options[26, 3] = "==";
        correctAnswers[26] = 1; // &&

        // Question 28
        questions[27] = "What is a namespace?";
        options[27, 0] = "Method name";
        options[27, 1] = "Variable type";
        options[27, 2] = "Container for related types";
        options[27, 3] = "Access modifier";
        correctAnswers[27] = 2; // Container for related types

        // Question 29
        questions[28] = "What is a delegate?";
        options[28, 0] = "Type of class";
        options[28, 1] = "Reference to a method";
        options[28, 2] = "Exception handler";
        options[28, 3] = "Memory pointer";
        correctAnswers[28] = 1; // Reference to a method

        // Question 30
        questions[29] = "What is the 'params' keyword for?";
        options[29, 0] = "Parameter validation";
        options[29, 1] = "Optional parameters";
        options[29, 2] = "Named parameters";
        options[29, 3] = "Variable number of parameters";
        correctAnswers[29] = 3; // Variable number of parameters
    }
}
