namespace Backend_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] shapeCircle = new[] { "kreis", "circle" };
            string[] shapeRectangle = new[] { "rechteck", "rectangle" };
            string[] shapeTriangle = new[] { "dreieck", "triangle" };
            string[] stringQuit = new[] { "quit", "close", "exit", "verlassen", "q" };

            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine("\"q\", \"quit\", \"close\", \"exit\", \"verlassen\" zum beenden!");
                Console.WriteLine("Zulässige Eingaben:\n \"Dreieck\", \"Triangle\", \"Rechteck\", \"Rectangle\", \"Kreis\", \"Circle\"");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.Write("Eingabe der Form: ");
                string? eingabe = Console.ReadLine().ToLower();

                if (shapeCircle.Contains(eingabe))
                {
                    Console.WriteLine("Circle ausgewählt");
                    CalcCircle();
                }
                else if (shapeRectangle.Contains(eingabe))
                {
                    Console.WriteLine("Rectangle ausgewählt");
                    CalcRectangle();
                }
                else if (shapeTriangle.Contains(eingabe))
                {
                    Console.WriteLine("Triangle ausgewählt");
                    CalcTriangle();
                }
                else if (stringQuit.Contains(eingabe))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Keine richtige Eingabe");
                }

                Console.WriteLine();
            }
        }

        public static void CalcCircle()
        {
            Console.WriteLine("Berechne Kreis...");
            Console.WriteLine();
            double radius = 0.0d;
            bool wrong_input = false;

            do
            {
                wrong_input = false;
                try
                {
                    Console.Write("Radius eingeben (in cm): ");
                    radius = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}");
                    wrong_input = true;
                }
            }
            while (wrong_input);

            Console.WriteLine($"Gewählter Radius: {radius}");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(Math.PI * Math.Pow(radius, 2), 2)}cm^2 Umfang: {Math.Round(2 * Math.PI * radius, 2)}cm");
        }

        public static void CalcRectangle()
        {
            Console.WriteLine("Berechne Rechteck...");
            Console.WriteLine();
            double site_a = 0.0d;
            double site_b = 0.0d;
            bool wrong_input = false;

            do
            {
                wrong_input = false;
                try
                {
                    Console.Write("Seitenlänge A eingeben (in cm): ");
                    site_a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Seitenlänge B eingeben (in cm): ");
                    site_b = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}");
                    wrong_input = true;
                }
            }
            while (wrong_input);

            Console.WriteLine($"Gewählte Seitenlänge A: {site_a}cm B: {site_b}cm");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(site_a * site_b, 2)}cm^2 Umfang: {Math.Round(2 * (site_a + site_b), 2)}cm");
        }

        public static void CalcTriangle()
        {
            Console.WriteLine("Berechne Dreieck...");
            Console.WriteLine();
            double site_a = 0.0d;
            double site_b = 0.0d;
            double site_c = 0.0d;
            bool wrong_input = false;

            do
            {
                wrong_input = false;
                try
                {
                    Console.Write("Seitenlänge A(Kathete) eingeben (in cm): ");
                    site_a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Seitenlänge B(Kathete) eingeben (in cm): ");
                    site_b = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Seitenlänge C(Hypothenuse) eingeben (in cm): ");
                    site_c = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}");
                    wrong_input = true;
                }
            }
            while (wrong_input);
            Console.WriteLine($"Gewählte Seitenlänge A: {site_a}cm B: {site_b}cm C: {site_c}cm");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(site_a * site_b * .5, 2)}cm^2 Umfang: {Math.Round(site_a + site_b + site_c, 2)}cm");
        }
    }
}