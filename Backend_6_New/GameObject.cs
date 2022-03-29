namespace Backend_6_New
{
    internal class GameObject
    {
        private bool againstAi = false;
        private bool gameOver = false;
        private Cell[,] playingField = new Cell[3, 3];
        private int turn = 1;

        public void StartGameLoop()
        {
            Setup();
            while (!gameOver)
            {
                TurnInput();
                CheckWinner();
            }
        }

        public void Setup()
        {
            gameOver = false;
            turn = 1;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    playingField[row, col] = new Cell();
                }
            }

            bool failedInput = false;
            string? input = string.Empty;
            do
            {
                failedInput = false;
                try
                {
                    Console.Write("1 für 1 Spieler, 2 für 2 Spieler: ");
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            againstAi = true;
                            break;
                        case "2":
                            againstAi = false;
                            break;
                        default:
                            throw new ArgumentException("Ungültige Eingabe!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}\n");
                    failedInput = true;
                }
            }
            while (failedInput);

            Console.WriteLine($"Neues Spiel gestartet; Gegen Computer = {againstAi}\n");
        }

        public void PrintField()
        {
            Console.WriteLine("  123");
            for (int a = 0; a < 3; a++)
            {
                Console.WriteLine($"{a + 1} {playingField[a, 0].CurrentSymbol}{playingField[a, 1].CurrentSymbol}{playingField[a, 2].CurrentSymbol}");
            }
        }

        public void TurnInput()
        {
            int inputRow = 0;
            int inputCol = 0;
            char playerSymbol;
            if (turn % 2 == 0)
            {
                playerSymbol = 'O';
            }
            else
            {
                playerSymbol = 'X';
            }

            if (againstAi && turn % 2 == 0)
            {
                AiTurn();
            }
            else
            {
                Console.Clear();
                bool failedInput = false;
                do
                {
                    failedInput = false;
                    try
                    {
                        PrintField();
                        Console.WriteLine("\nGültig sind 1, 2, 3!");
                        Console.Write("\nWelche Row: ");
                        inputRow = Convert.ToInt16(Console.ReadLine()) - 1;
                        Console.Write("\nWelche Col: ");
                        inputCol = Convert.ToInt16(Console.ReadLine()) - 1;

                        if (inputRow > 2 || inputRow < 0 || inputCol > 2 || inputCol < 0)
                        {
                            throw new ArgumentException("Ungültige Eingabe!\n");
                        }

                        if (playingField[inputRow, inputCol].CurrentSymbol != '/')
                        {
                            throw new ArgumentException("Feld bereits belegt!\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}\n");
                        failedInput = true;
                    }
                }
                while (failedInput);
                playingField[inputRow, inputCol].CurrentSymbol = playerSymbol;
            }

            turn++;
        }

        public void AiTurn()
        {
            List<Tuple<int, int>> freeSpaces = new List<Tuple<int, int>>();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (playingField[row, col].CurrentSymbol == '/')
                    {
                        freeSpaces.Add(new Tuple<int, int>(row, col));
                    }
                }
            }

            Random rand = new();
            var selectedField = freeSpaces[rand.Next(0, freeSpaces.Count)];
            playingField[selectedField.Item1, selectedField.Item2].CurrentSymbol = 'O';
        }

        public void CheckWinner()
        {
            bool foundWinner = false;
            if (turn > 2)
            {
                // Check Rows
                for (int row = 0; row < 3; row++)
                {
                    foundWinner = CheckEqual(playingField[row, 0].CurrentSymbol, playingField[row, 1].CurrentSymbol, playingField[row, 2].CurrentSymbol);
                    if (foundWinner)
                    {
                        Console.WriteLine($"Gewonnen hat {playingField[row, 0].CurrentSymbol}");
                        break;
                    }
                }

                // Check Columns
                if (!foundWinner)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        foundWinner = CheckEqual(playingField[0, col].CurrentSymbol, playingField[1, col].CurrentSymbol, playingField[2, col].CurrentSymbol);
                        if (foundWinner)
                        {
                            Console.WriteLine($"Gewonnen hat {playingField[0, col].CurrentSymbol}");
                            break;
                        }
                    }
                }

                // Check Diagonals
                if (!foundWinner)
                {
                    foundWinner = CheckEqual(playingField[0, 0].CurrentSymbol, playingField[1, 1].CurrentSymbol, playingField[2, 2].CurrentSymbol);
                    if (foundWinner)
                    {
                        Console.WriteLine($"Gewonnen hat {playingField[1, 1].CurrentSymbol}");
                    }
                }

                if (!foundWinner)
                {
                    foundWinner = CheckEqual(playingField[0, 2].CurrentSymbol, playingField[1, 1].CurrentSymbol, playingField[2, 0].CurrentSymbol);
                    if (foundWinner)
                    {
                        Console.WriteLine($"Gewonnen hat {playingField[1, 1].CurrentSymbol}");
                    }
                }
            }

            if (turn == 9 && !foundWinner)
            {
                gameOver = true;
                Console.WriteLine("Untentschieden!");
            }

            gameOver = foundWinner;
        }

        public bool CheckEqual(char a, char b, char c)
        {
            return a == b && b == c && a != '/';
        }
    }
}
