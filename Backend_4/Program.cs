namespace Backend_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number (empty to exit): ");
            string? number = Console.ReadLine();

            while (!string.IsNullOrEmpty(number))
            {

                Console.Write("    Enter number base (2-36): ");
                int numberBase = int.Parse(Console.ReadLine());

                Console.Write("Enter new number base (2-36): ");
                int newBase = int.Parse(Console.ReadLine());

                string newNumber = ConvertNumber(number, numberBase, newBase);

                Console.WriteLine("{0} ({1}) = {2} ({3})",
                                  number, numberBase, newNumber, newBase);

                Console.Write("Enter number (empty to exit): ");
                number = Console.ReadLine();
            }

            static char intToChar(int value)
            {
                /*
                Ascii tabelle: char => int
                '0' => 48
                'A' => 65
                'Z' => 90
                my number needs to be between 65 and 90 to convert number > 9 to a character
                Example: 
                 */
                char result;

                if (value < 10)
                {
                    //look up int vlaue of '0' add the number and then look up what the char value of the sum is
                    //alternative: result = (char)('0' + value);
                    result = (char)(48 + value);
                }
                else
                {
                    //alternative: result = (char)('A' - 10 + value); or = (char)('7' + value);
                    //cant start with (int)'A' because value will always be atleast 10, but if it is 10 then i dont want to add it to (int)'A' becasue that would give 'K' or 75  and not 'A' or 65
                    // so i either start with 55 (10 less then (int)'A') or i subtract 10
                    result = (char)(55 + value);
                }

                return result;
            }
            static int charToInt(char digit)
            {
                int result;
                if (digit >= '0' && digit <= '9')
                {
                    //calc the Ascii code difference of the number and ascii code for '0'
                    result = digit - '0';
                }
                else
                {
                    result = digit - 55;
                }
                return result;
            }

            static string ConvertNumber(string number, int numberBase, int newBase)
            {
                string newNumber = "";
                while (number != "0")
                {
                    int reminder = 0;
                    number = divide(number, numberBase, newBase, out reminder);
                    var newDigit = intToChar(reminder);
                    newNumber = newDigit + newNumber;
                }

                if (newNumber == "")
                {
                    newNumber = "0";
                }
                return newNumber;
            }

            static string divide(string number, int numberBase, int divisor, out int remainder)
            {
                remainder = 0;
                var result = "";

                for (int i = 0; i < number.Length; i++)
                {
                    var digitValue = charToInt(number[i]);
                    remainder = numberBase * remainder + digitValue;
                    var newDigitValue = remainder / divisor;
                    remainder = remainder % divisor;
                    if (newDigitValue > 0 || result != "0")
                    {
                        var newDigit = intToChar(newDigitValue);
                        result = result + newDigit;
                    }
                    if (result == "")
                    {
                        result = "0";
                    }
                }
                return result;
            }
        }
    }
}
