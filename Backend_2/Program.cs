namespace Backend_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] shape_circle = new[] { "kreis", "circle" };
            string[] shape_rectangle = new[] { "rechteck", "rectangle" };
            string[] shape_triangle = new[] { "dreieck", "triangle" };
            string[] string_quit = new[] { "quit", "close", "exit", "verlassen", "q" };

            while (true)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("\"q\", \"quit\", \"close\", \"exit\", \"verlassen\" zum beenden!");
                Console.WriteLine("Zulässige Eingaben:\n \"Dreieck\", \"Triangle\", \"Rechteck\", \"Rectangle\", \"Kreis\", \"Circle\"");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.Write("Eingabe der Form: ");
                string? eingabe = Console.ReadLine().ToLower();

                if (shape_circle.Contains(eingabe))
                {
                    Console.WriteLine("Circle ausgewählt");
                    calc_circle();
                }
                else if (shape_rectangle.Contains(eingabe))
                {
                    Console.WriteLine("Rectangle ausgewählt");
                    calc_rectangle();
                }
                else if (shape_triangle.Contains(eingabe))
                {
                    Console.WriteLine("Triangle ausgewählt");
                    calc_Triangle();
                }
                else if (string_quit.Contains(eingabe))
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
        static void calc_circle()
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
            } while (wrong_input);

            Console.WriteLine($"Gewählter Radius: {radius}");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(Math.PI * Math.Pow(radius, 2), 2)}cm^2 Umfang: {Math.Round((2 * Math.PI * radius), 2)}cm");
        }

        static void calc_rectangle()
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
            } while (wrong_input);

            Console.WriteLine($"Gewählte Seitenlänge A: {site_a}cm B: {site_b}cm");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(site_a * site_b, 2)}cm^2 Umfang: {Math.Round(2 * (site_a + site_b), 2)}cm");
        }

        static void calc_Triangle()
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
            } while (wrong_input);
            Console.WriteLine($"Gewählte Seitenlänge A: {site_a}cm B: {site_b}cm C: {site_c}cm");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round((site_a * site_b)) * .5,2}cm^2 Umfang: {Math.Round(site_a + site_b + site_c, 2)}cm");
        }
    }
}