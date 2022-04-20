namespace Backend_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Get User-Input: Number to convert; Base of the Number to convert; Base of the result
            Console.Write("Zahl zum Umrechnen  (leer lassen zum verlassen): ");
            string? number = Console.ReadLine();

            while (!string.IsNullOrEmpty(number))
            {
                Console.Write("    Basis der Zahl (2-36): ");
                int numberBase = int.Parse(Console.ReadLine());

                Console.Write("Gewünschte Basis(2-36): ");
                int newBase = int.Parse(Console.ReadLine());

                Console.WriteLine($"{number} => Binär: {ConvertNumber(number, numberBase, 2)}");
                Console.WriteLine($"{number} => Dezimal: {ConvertNumber(number, numberBase, 10)}");
                Console.WriteLine($"{number} => Hexadezimal: {ConvertNumber(number, numberBase, 16)}");
                Console.WriteLine($"{number} => Gewünschte Basis {newBase}: {ConvertNumber(number, numberBase, newBase)}");

                Console.WriteLine();
                Console.Write("Zahl zum Umrechnen  (leer lassen zum verlassen): ");
                number = Console.ReadLine();
            }
        }

        /// <summary>
        /// Takes an integer and converts it to the respective character.
        /// </summary>
        /// <param name="value">Number to convert</param>
        /// <returns>Character of the Number</returns>
        public static char IntToChar(int value)
        {
            char result;

            if (value < 10)
            {
                result = (char)(48 + value);
            }
            else
            {
                result = (char)(55 + value);
            }

            return result;
        }

        /// <summary>
        /// Takes a character and converts it to the respective integer.
        /// </summary>
        /// <param name="digit">CHarcter to convert</param>
        /// <returns>Integer of the character</returns>
        public static int CharToInt(char digit)
        {
            int result;
            if (digit >= '0' && digit <= '9')
            {
                result = digit - '0';
            }
            else
            {
                result = digit - 55;
            }

            return result;
        }

        /// <summary>
        /// Converts a number from any base to a new number with a specific base.
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <param name="numberBase">Base of the number thats being converted</param>
        /// <param name="newBase">Base of the resulting number</param>
        /// <returns>Number with the new base</returns>
        public static string ConvertNumber(string number, int numberBase, int newBase)
        {
            string newNumber = string.Empty;
            while (number != "0")
            {
                int reminder = 0;
                number = Divide(number, numberBase, newBase, out reminder);
                var newDigit = IntToChar(reminder);
                newNumber = newDigit + newNumber;
            }

            if (newNumber == string.Empty)
            {
                newNumber = "0";
            }

            return newNumber;
        }

        private static string Divide(string number, int numberBase, int divisor, out int remainder)
        {
            remainder = 0;
            var result = string.Empty;

            for (int i = 0; i < number.Length; i++)
            {
                var digitValue = CharToInt(number[i]);
                remainder = (numberBase * remainder) + digitValue;
                var newDigitValue = remainder / divisor;
                remainder = remainder % divisor;
                if (newDigitValue > 0 || result != "0")
                {
                    var newDigit = IntToChar(newDigitValue);
                    result = result + newDigit;
                }

                if (result == string.Empty)
                {
                    result = "0";
                }
            }

            return result;
        }
    }
}
