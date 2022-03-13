using System;

namespace Backend_1
{
	class Program
	{
		static void Main(string[] args)
		{
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(evaluateTernary(i +1));
            }
		}

		public static string evaluate(int number)
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
        public static string evaluateTernary(int num)
        {
            string result = "";

            result = (num % 5 == 0 & num % 3 == 0) ? "FizzBuzz" : (num % 5 == 0) ? "Buzz" : (num % 3 == 0) ? "Fizz" : $"{num}";

            return result;
        }
	}
}
