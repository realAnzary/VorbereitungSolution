namespace Backend_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? input;
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine("Spielmodi auswählen: 1 für selber Raten, 2 für Computer auf einfach, 3 für Computer auf normal, 4 für Computer auf clever ");
                Console.WriteLine("\"Q\", \"Quit\", \"Close\", \"Exit\" zum beenden!");
                Console.Write("Deine Auswahl: ");
                input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                        playerGuessing();
                        break;
                    case "2":
                        computerSuperStupid();
                        break;
                    case "3":
                        computerStupid();
                        break;
                    case "4":
                        computerSmart();
                        break;
                    case "q":
                    case "quit":
                    case "close":
                    case "exit":
                        playAgain = false;
                        break;
                    default:
                        Console.WriteLine("Keine gültige Eingabe, nur Zahlen 1-4 sind ok!");
                        break;
                }
            }
        }

        static void playerGuessing()
        {
            int counter = 0;
            Random rand = new();
            int selectedNumber = (int)rand.NextInt64(1, 101);

            while (true)
            {
                bool inputNotValid = false;
                string? input;
                do
                {
                    Console.Write("Rateversuch eingeben: ");
                    input = Console.ReadLine();
                    int inputToNumber;
                    inputNotValid = false;
                    try
                    {
                        inputToNumber = Convert.ToInt16(input);
                        if (inputToNumber > 100 | inputToNumber < 1)
                        {
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

                } while (inputNotValid);


                counter++;
                if (Convert.ToInt32(input) == selectedNumber)
                {
                    Console.WriteLine($"Korrekt geraten, die Zahl war {selectedNumber}");
                    break;
                }
                string clue = (Convert.ToInt16(input) > selectedNumber) ? "Zahl ist kleiner als deine Eingabe" : "Zahl ist größer als Eingabe";
                Console.WriteLine(clue);
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine($"Anzahl der gebrauchten Versuche: {counter}");
        }
        static void computerSuperStupid()
        {
            //only random guesses, no real logic
            int counter = 0;
            bool inputNotValid = false;
            string? input;
            do
            {
                Console.Write("Zahl eingeben(1-100): ");
                input = Console.ReadLine();
                int inputToNumber;
                inputNotValid = false;
                try
                {
                    inputToNumber = Convert.ToInt16(input);
                    if (inputToNumber > 100 | inputToNumber < 1)
                    {
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

            } while (inputNotValid);

            //start guessing
            Random rand = new Random();


            while (true)
            {
                int guess = (int)rand.NextInt64(1, 101);
                counter++;
                Console.WriteLine($"Der Computer tippt auf: {guess}");
                if (guess == Convert.ToInt16(input))
                {
                    Console.WriteLine($"Korrekt geraten, die Zahl war {guess}");
                    break;
                }
                else
                {
                    //clue from user
                    string? clue;
                    bool validClue = false;
                    do
                    {
                        Console.Write("Ist die gesuchte Zahl größer oder kleiner? ");
                        clue = Console.ReadLine();
                        if ((clue.ToLower() == "kleiner" && guess > Convert.ToInt16(input)) || (clue.ToLower() == "größer" && guess < Convert.ToInt16(input)))
                        {
                            validClue = true;
                        }
                        else
                        {
                            Console.WriteLine("Tipp ist nicht richtig, bitte korrigieren!");
                        }

                    } while (!validClue);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                }
            }
            Console.WriteLine($"Anzahl der vom Computer gebrauchten Versuche: {counter}");


        }
        static void computerStupid()
        {
            //randomly guessing but reacts according to the player feedback
            int counter = 0;
            bool inputNotValid = false;
            string? input;
            do
            {
                Console.Write("Zahl eingeben(1-100): ");
                input = Console.ReadLine();
                int inputToNumber;
                inputNotValid = false;
                try
                {
                    inputToNumber = Convert.ToInt16(input);
                    if (inputToNumber > 100 | inputToNumber < 1)
                    {
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

            } while (inputNotValid);

            //start guessing
            Random rand = new Random();
            int upperLimit = 101;
            int lowerLimit = 1;


            while (true)
            {
                int guess = (int)rand.NextInt64(lowerLimit, upperLimit);
                counter++;
                Console.WriteLine($"Der Computer tippt auf: {guess}");
                if (guess == Convert.ToInt16(input))
                {
                    Console.WriteLine($"Korrekt geraten, die Zahl war {guess}");
                    break;
                }
                else
                {
                    //clue from user
                    string? clue;
                    bool validClue = false;
                    do
                    {
                        Console.Write("Ist die gesuchte Zahl größer oder kleiner? ");
                        clue = Console.ReadLine();
                        if ((clue.ToLower() == "kleiner" && guess > Convert.ToInt16(input)) || (clue.ToLower() == "größer" && guess < Convert.ToInt16(input)))
                        {
                            validClue = true;
                        }
                        else
                        {
                            Console.WriteLine("Tipp ist nicht richtig, bitte korrigieren!");
                        }

                    } while (!validClue);

                    //interpret clue
                    if (clue == "kleiner")
                    {
                        upperLimit = guess;
                    }
                    else
                    {
                        lowerLimit = guess + 1;
                    }
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                }
            }
            Console.WriteLine($"Anzahl der vom Computer gebrauchten Versuche: {counter}");
        }
        static void computerSmart()
        {
            //divide and conquer principle, seems like the most consistent approach to this
            int counter = 0;
            bool inputNotValid = false;
            string? input;
            do
            {
                Console.Write("Zahl eingeben(1-100): ");
                input = Console.ReadLine();
                int inputToNumber;
                inputNotValid = false;
                try
                {
                    inputToNumber = Convert.ToInt16(input);
                    if (inputToNumber > 100 | inputToNumber < 1)
                    {
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

            } while (inputNotValid);
            // start guessing
            Random rand = new Random();
            int upperLimit = 101;
            int lowerLimit = 1;
            while (true)
            {
                int check = upperLimit - lowerLimit;
                int guess;
#warning look if the check for the first guess needs to have an extra implementation
                if (counter == 0)
                {
                    if (upperLimit - lowerLimit % 2 == 0)
                    {
                        guess = (upperLimit - lowerLimit) / 2;
                        Console.WriteLine($"gerade | {guess}");
                    }
                    else
                    {
                        guess = (upperLimit - lowerLimit) / 2;
                        Console.WriteLine($"ungerade  | {guess}");
                    }
                }
                else
                {
                    int difference = upperLimit - lowerLimit;
                    guess = lowerLimit + (difference / 2);
                }
                counter++;
                Console.WriteLine($"Der Computer tippt auf: {guess}");
                if (guess == Convert.ToInt16(input))
                {
                    Console.WriteLine($"Korrekt geraten, die Zahl war {guess}");
                    break;
                }
                else
                {
                    //clue from user
                    string? clue;
                    bool validClue = false;
                    do
                    {
                        Console.Write("Ist die gesuchte Zahl größer oder kleiner? ");
                        clue = Console.ReadLine();
                        if ((clue.ToLower() == "kleiner" && guess > Convert.ToInt16(input)) || (clue.ToLower() == "größer" && guess < Convert.ToInt16(input)))
                        {
                            validClue = true;
                        }
                        else
                        {
                            Console.WriteLine("Tipp ist nicht richtig, bitte korrigieren!");
                        }

                    } while (!validClue);

                    //interpret clue
                    if (clue == "kleiner")
                    {
                        upperLimit = guess;
                    }
                    else
                    {
                        lowerLimit = guess + 1;
                    }
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                }
            }
            Console.WriteLine($"Anzahl der vom Computer gebrauchten Versuche: {counter}");
        }
    }
}