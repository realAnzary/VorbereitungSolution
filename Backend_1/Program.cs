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

		public static string evaluate(int num)
		{
			if (num % 5 == 0 && num % 3 == 0)
			{
				return "FizzBuzz";
			}
			else if (num % 5 == 0)
			{
				return "Buzz";
			}
			else if (num % 3 == 0)
			{
				return "Fizz";
			}
			else
			{
				return $"{num}";
			}
		}
		public static string evaluateTernary(int num)
		{
			string result = "";

			 return result = (num % 5 == 0 & num % 3 == 0) ? "FizzBuzz" : (num % 5 == 0) ? "Buzz" : (num % 3 == 0) ? "Fizz" : $"{num}";
		}
	}
}
