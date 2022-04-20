namespace Backend_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Variables
            string? input;
            bool playAgain = true;

            // Get User-Input: What mode to play; Run until accepted input comes up
            while (playAgain)
            {
                Console.WriteLine("Spielmodi auswählen: 1 für selber Raten, 2 für Computer raten lassen.");
                Console.WriteLine("\"Q\", \"Quit\", \"Close\", \"Exit\" zum beenden!");
                Console.Write("Deine Auswahl: ");
                input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                        // Player is guessing
                        PlayerGuessing();
                        break;
                    case "2":
                        // Computer is guessing
                        ComputerSmart();
                        break;
                    case "q":
                    case "quit":
                    case "close":
                    case "exit":
                    case "":
                        // Exit application
                        playAgain = false;
                        break;
                    default:
                        // Unknown Inputs
                        Console.WriteLine("Keine gültige Eingabe, nur Zahlen 1-4 sind ok!");
                        break;
                }
            }
        }

        /// <summary>
        /// Gameloop when the player is guessing
        /// </summary>
        public static void PlayerGuessing()
        {
            // Variables
            // Turn counter
            int counter = 0;
            Random rand = new Random();

            // Target number
            int selectedNumber = (int)rand.NextInt64(1, 101);

            // Loop to get a valid User-Input
            while (true)
            {
                bool inputNotValid = false;
                string? input;
                do
                {
                    Console.Write("Rate-Versuch eingeben: ");
                    input = Console.ReadLine();
                    int inputToNumber;
                    inputNotValid = false;
                    try
                    {
                        // Try converting to number and check if guess is in bounds
                        inputToNumber = Convert.ToInt16(input);
                        if (inputToNumber > 100 | inputToNumber < 1)
                        {
                            // Mark as invalid value
                            inputNotValid = true;
                            throw new ArgumentException("Zahl muss mindestens 1 und kann maximal 100 sein!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}");
                        inputNotValid = true;
                        Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    }
                }
                while (inputNotValid);

                // Check if guess is correct and increase turn
                counter++;
                if (Convert.ToInt32(input) == selectedNumber)
                {
                    Console.WriteLine($"Korrekt geraten, die Zahl war {selectedNumber}");
                    break;
                }

                // Feddback if target number is higher or lower than guess
                string clue = (Convert.ToInt16(input) > selectedNumber) ? "Zahl ist kleiner als deine Eingabe" : "Zahl ist größer als Eingabe";
                Console.WriteLine(clue);
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
            }

            // End of Gameloop
            Console.WriteLine($"Anzahl der gebrauchten Versuche: {counter}");
        }

        /// <summary>
        /// Gameloop if the computer is guessing
        /// </summary>
        public static void ComputerSmart()
        {
            // Variables
            // Turn counter
            int counter = 0;
            bool inputNotValid = false;
            string? selectedNumber;

            // Loop to get valid User-Input for the target number
            do
            {
                Console.Write("Zahl eingeben(1-100): ");
                selectedNumber = Console.ReadLine();
                inputNotValid = false;
                try
                {
                    // Conversion to integer and check if input is in bounds
                    int inputToNumber = Convert.ToInt16(selectedNumber);
                    if (inputToNumber > 100 | inputToNumber < 1)
                    {
                        // Mark as invalid input
                        inputNotValid = true;
                        throw new ArgumentException("Zahl muss mindestens 1 und kann maximal 100 sein!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}");
                    inputNotValid = true;
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                }
            }
            while (inputNotValid);

            // start the guessing loop
            // initialise unchanged limits
            int lowerLimit = 1;
            int upperLimit = 101;

            Random rand = new Random();

            // start gameloop with a guess by computer
            while (true)
            {
                // Try guessing in the center of upper and lower limit of the valid numbers
                int guess;

                if (counter == 0)
                {
                    // First turn guess to make it corretly guess 50 first turn
                    guess = (upperLimit - lowerLimit) / 2;
                }
                else
                {
                    // get difference of the limits, divide by two and add lower limit
                    int difference = upperLimit - lowerLimit;
                    guess = lowerLimit + (difference / 2);
                }

                // Check if guess corect and increase counter
                counter++;
                Console.WriteLine($"Der Computer tippt auf: {guess}");
                if (guess == Convert.ToInt16(selectedNumber))
                {
                    // If guess is correct
                    Console.WriteLine($"Korrekt geraten, die Zahl war {guess}");
                    break;
                }
                else
                {
                    // If guess is incorrect change the limits for next guess
                    if (Convert.ToInt16(selectedNumber) > guess)
                    {
                        lowerLimit = guess + 1;
                    }
                    else
                    {
                        upperLimit = guess - 1;
                    }
                }
            }

            Console.WriteLine($"Anzahl der vom Computer gebrauchten Versuche: {counter}\n");
        }
    }
}