namespace Backend_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 99; i++)
            {
                Console.WriteLine(EvaluateTernary(i + 1));
            }
        }

        public static string Evaluate(int number)
        {
            if (number % 5 == 0 && number % 3 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else
            {
                return $"{number}";
            }
        }

        public static string EvaluateTernary(int number)
        {
            string result = string.Empty;
            return result = (number % 5 == 0 && number % 3 == 0) ? "FizzBuzz" : (number % 5 == 0) ? "Buzz" : (number % 3 == 0) ? "Fizz" : $"{number}";
        }
    }
}