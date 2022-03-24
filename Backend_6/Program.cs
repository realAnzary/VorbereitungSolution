namespace Backend_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("\"1\" für 1 Spieler, \"2\" für 2 Spieler: ");
            string? input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                switch (input.ToLower())
                {
                    case "1":
                        StartGameLoop(true);
                        break;
                    case "2":
                        StartGameLoop(false);
                        break;
                    default:
                        Console.WriteLine("Keine gültige Eingabe!\n");
                        break;
                }

                Console.Write("\"1\" für 1 Spieler, \"2\" für 2 Spieler: ");
                input = Console.ReadLine();
            }
        }

        public static void StartGameLoop(bool againstPc)
        {
            bool againstAi = againstPc;
            bool gameOver = false;
            char[,] field = new char[3, 3];
            int turn = 1;
            char winner = default(char);

            while (!gameOver)
            {
                field = PlayerTurn(field, turn, againstAi);
                Console.Clear();
                Console.Write("Aktuelles Feld:");
                PrintField(field);
                Console.WriteLine();
                winner = CheckWin(field, turn);
                gameOver = (winner != default(char)) ? true : false;
                turn++;
            }

            Console.WriteLine();
            Console.WriteLine($"Gewonnen hat {winner}\n");
        }

        public static char[,] PlayerTurn(char[,] currentField, int currentTurn, bool againstAi)
        {
            char playerSymbol = (currentTurn % 2 != 0) ? 'X' : 'O';

            bool wrongInput = false;
            int inputRow = 0;
            int inputColumn = 0;
            if (againstAi && playerSymbol == 'O')
            {
                 return AiTurn(currentField);
            }
            else
            {
                do
                {
                    wrongInput = false;
                    try
                    {
                        for (int i = 1; i < 4; i++)
                        {
                            Console.WriteLine($"{i,-1}MMM");
                        }

                        Console.Write("Row (1 - 3): ");
                        inputRow = Convert.ToInt16(Console.ReadLine()) - 1;

                        Console.WriteLine($"\n{1}{2}{3}\nMMM\nMMM\nMMM");

                        Console.Write("Column (1 - 3): ");
                        inputColumn = Convert.ToInt16(Console.ReadLine()) - 1;

                        if (inputRow > 2 || inputRow < 0 || inputColumn > 2 || inputColumn < 0)
                        {
                            throw new ArgumentException("Eine der Eingabe ist nicht im gültigen Bereich von 1, 2, 3!");
                        }

                        if (currentField[inputRow, inputColumn] != default(char))
                        {
                            throw new ArgumentException("Das Feld ist schon belegt!");
                        }
                    }
                    catch (Exception ex)
                    {
                        wrongInput = true;
                        Console.WriteLine($"Fehler: {ex.GetType()} | {ex.Message}");
                        Console.WriteLine();
                    }
                }
                while (wrongInput);
                currentField[inputRow, inputColumn] = playerSymbol;
            }

            return currentField;
        }

        public static char[,] AiTurn(char[,] currentField)
        {
            var availableSpaces = new List<Tuple<int, int>>();
            var rand = new Random();
            var guess = new Tuple<int, int>(0, 0);

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (currentField[row, column] == default(char))
                    {
                        availableSpaces.Add(new Tuple<int, int>(row, column));
                    }
                }
            }

            guess = availableSpaces[rand.Next(0, availableSpaces.Count)];
            currentField[guess.Item1, guess.Item2] = 'O';

            return currentField;
        }

        public static char CheckWin(char[,] currentField, int currentTurn)
        {
            char winner = default(char);

            for (int i = 0; i < 3; i++)
            {
                winner = CheckEqual(currentField[i, 0], currentField[i, 1], currentField[i, 2]);
                if (winner != default(char))
                {
                    break;
                }

                winner = CheckEqual(currentField[0, i], currentField[1, i], currentField[2, i]);
                if (winner != default(char))
                {
                    break;
                }

                winner = CheckEqual(currentField[0, 0], currentField[1, 1], currentField[2, 2]);
                if (winner != default(char))
                {
                    break;
                }

                winner = CheckEqual(currentField[0, 2], currentField[1, 1], currentField[2, 0]);
                if (winner != default(char))
                {
                    break;
                }
            }

            return winner;
        }

        public static char CheckEqual(char a, char b, char c)
        {
            return ((a == b && b == c) && a != default(char)) ? a : default(char);
        }

        public static void PrintField(char[,] currentField)
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == '\0')
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(currentField[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
