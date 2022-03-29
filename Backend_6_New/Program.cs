namespace Backend_6_New
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameObject game = new GameObject();
            game.StartGameLoop();

            Console.Write("Nochmal?(leer lassen zum verlassen): ");
            string? input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                game.StartGameLoop();
                Console.Write("Nochmal?(leer lassen zum verlassen): ");
                input = Console.ReadLine();
            }
        }
    }
}
