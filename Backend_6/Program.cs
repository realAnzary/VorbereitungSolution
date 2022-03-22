namespace Backend_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameOver = false;
            char[,] field = new char[3, 3];
            int turn = 1;

            while (!gameOver)
            {
                field = playerTurn(field, turn);
                printField(field);
                Console.WriteLine();
                gameOver = checkWin(field, turn);
                turn++;
            }
        }

        static char[,] playerTurn(char[,] currentField, int currentTurn)
        {
            //get player symbol
            char playerSymbol = (currentTurn % 2 != 0)? 'X': 'O';            

            //get player input for field
            bool wrongInput = false;
            int inputRow = 0;
            int inputColumn = 0;
            do
            {
                wrongInput = false;
                try
                {
                    Console.Write("In welche Reihe (0-2): ");
                    inputRow = Convert.ToInt16(Console.ReadLine());
                    Console.Write("In welche Spalte (0-2): ");
                    inputColumn = Convert.ToInt16(Console.ReadLine());

                    //keine zahl von 0 bis 2
                    //feld belegt

                    if (inputRow > 2 || inputRow < 0 || inputColumn > 2 || inputColumn < 0)
                    {
                        throw new ArgumentException("Eine der Eingabe ist nicht im gültigen Bereich von 0,1,2!");
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

            } while (wrongInput);

            //change field
            currentField[inputRow, inputColumn] = playerSymbol;

            return currentField;
        }
        static bool checkWin(char[,] currentField, int currentTurn)
        {

            //check horizontal
            checkEqual(currentField[0, 0], currentField[0, 1], currentField[0, 2]);
            checkEqual(currentField[1, 0], currentField[1, 1], currentField[1, 2]);
            checkEqual(currentField[2, 0], currentField[2, 1], currentField[2, 2]);

            //check vertical

            checkEqual(currentField[0, 0], currentField[1, 0], currentField[2, 0]);
            checkEqual(currentField[0, 1], currentField[1, 1], currentField[2, 1]);
            checkEqual(currentField[0, 2], currentField[1, 2], currentField[2, 2]);

            //check crossing
            checkEqual(currentField[0, 0], currentField[1, 1], currentField[2, 2]);
            checkEqual(currentField[0, 2], currentField[1, 1], currentField[2, 0]);
            return false;
        }
        static bool checkEqual(char a, char b, char c)
        {
            return (a == b && b == c);
        }
        static void printField(char[,] currentField)
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == '\0')
                    {
                        Console.Write('M');
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
