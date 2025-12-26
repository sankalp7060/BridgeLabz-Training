using System;

class SnakeAndLadderGame{
    const int BOARD_SIZE = 100;
    static Random random = new Random();

    static int[] snakes = new int[101];
    static int[] ladders = new int[101];

    static void Main(){
        Console.WriteLine("\nWelcome to Snake & Ladder Game\n");

        InitializeSnakesAndLadders();

        int playerCount = GetPlayerCount();

        string[] players = new string[playerCount];
        int[] positions = new int[playerCount];
        bool[] isActive = new bool[playerCount];

        for (int i = 0; i < playerCount; i++){
            Console.Write($"Enter name for Player {i + 1}: ");
            players[i] = Console.ReadLine();
            positions[i] = 0;
            isActive[i] = true;
        }

        int activePlayers = playerCount;
        bool gameWon = false;

        // ---------------- GAME LOOP ----------------
        while (!gameWon){
            for (int i = 0; i < playerCount; i++){
                if (!isActive[i]) continue;

                Console.WriteLine($"\n➡ {players[i]}'s Turn (Position: {positions[i]})");
                Console.Write("Press ENTER to roll dice or type EXIT to leave: ");

                string input = Console.ReadLine();

                // ---------- PLAYER EXIT ----------
                if (input.Equals("EXIT", StringComparison.OrdinalIgnoreCase)){
                    Console.WriteLine($" {players[i]} has left the game.");
                    isActive[i] = false;
                    activePlayers--;

                    // AUTO WIN IF ONLY ONE PLAYER LEFT
                    if (activePlayers == 1){
                        for (int j = 0; j < playerCount; j++){
                            if (isActive[j]){
                                Console.WriteLine($"\n {players[j]} WINS (Last player remaining)!");
                                gameWon = true;
                                break;
                            }
                        }
                    }

                    if (gameWon) break;
                    continue;
                }

                // ---------- DICE ROLL ----------
                int dice = RollDice();
                Console.WriteLine($" Dice Rolled: {dice}");

                int oldPosition = positions[i];
                int newPosition = oldPosition + dice;

                if (newPosition > BOARD_SIZE){
                    Console.WriteLine(" Move exceeds 100. Turn skipped.");
                    continue;
                }

                newPosition = ApplySnakeOrLadder(newPosition);
                positions[i] = newPosition;

                Console.WriteLine($" {oldPosition} → {newPosition}");

                // ---------- WIN CHECK ----------
                if (CheckWin(newPosition)){
                    Console.WriteLine($"\n {players[i]} WINS THE GAME!");
                    gameWon = true;
                    break;
                }
            }
        }

        Console.WriteLine("\nGame Over. Thanks for playing!");
    }

    // ---------- METHODS ----------

    static int RollDice(){
        return random.Next(1, 7);
    }

    static int ApplySnakeOrLadder(int position){
        if (snakes[position] != 0){
            Console.WriteLine($" Snake Bite! Down to {snakes[position]}");
            return snakes[position];
        }
        else if (ladders[position] != 0){
            Console.WriteLine($" Ladder! Up to {ladders[position]}");
            return ladders[position];
        }
        return position;
    }

    static bool CheckWin(int position){
        return position == BOARD_SIZE;
    }

    static void InitializeSnakesAndLadders(){
        // Snakes
        snakes[99] = 54;
        snakes[70] = 55;
        snakes[52] = 42;
        snakes[25] = 2;
        snakes[95] = 72;

        // Ladders
        ladders[6] = 25;
        ladders[11] = 40;
        ladders[60] = 85;
        ladders[46] = 90;
        ladders[17] = 69;
    }

    static int GetPlayerCount(){
        int count;
        do{
            Console.Write("Enter number of players (2 to 4): ");
            count = Convert.ToInt32(Console.ReadLine());
        }
        while (count < 2 || count > 4);

        return count;
    }
}
