for (int i = 0; i < 99; i++)
{
    Console.WriteLine(evaluateTernary(i + 1));
}

static string evaluate(int number)
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

static string evaluateTernary(int number)
{
    string result = "";
    return result = (number % 5 == 0 && number % 3 == 0) ? "FizzBuzz" : (number % 5 == 0) ? "Buzz" : (number % 3 == 0) ? "Fizz" : $"{number}";
}
