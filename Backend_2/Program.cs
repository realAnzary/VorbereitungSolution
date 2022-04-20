namespace Backend_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // List of all the accepted shapes and synonyms of the shape; all lower-case
            string[] shapeCircleNames = new[] { "kreis", "circle" };
            string[] shapeRectangleNames = new[] { "rechteck", "rectangle" };
            string[] shapeTriangleNames = new[] { "dreieck", "triangle" };
            string[] stringQuit = new[] { "quit", "close", "exit", "verlassen", "q", string.Empty };

            // Get User-Input: Name of the shape
            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine("\"q\", \"quit\", \"close\", \"exit\", \"verlassen\" zum beenden!");
                Console.WriteLine("Zulässige Eingaben:\n \"Dreieck\", \"Triangle\", \"Rechteck\", \"Rectangle\", \"Kreis\", \"Circle\"");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.Write("Eingabe der Form: ");

                // Convert User-Input to lower-case
                string? eingabe = Console.ReadLine().ToLower();

                // Execute the correct function to start the calculation process
                if (shapeCircleNames.Contains(eingabe))
                {
                    Console.WriteLine("´Kreis ausgewählt");
                    CalcCircle();
                }
                else if (shapeRectangleNames.Contains(eingabe))
                {
                    Console.WriteLine("Rechteck ausgewählt");
                    CalcRectangle();
                }
                else if (shapeTriangleNames.Contains(eingabe))
                {
                    Console.WriteLine("Dreieck ausgewählt");
                    CalcTriangle();
                }
                else if (stringQuit.Contains(eingabe))
                {
                    // Quit the application
                    break;
                }
                else
                {
                    // Unknown or unaccepted Input
                    Console.WriteLine("Keine gültige Eingabe!");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method to calculate radius and area of a circle.
        /// </summary>
        public static void CalcCircle()
        {
            Console.WriteLine("Berechne Kreis...");
            Console.WriteLine();

            // Variables
            double radius = 0.0d;
            bool wrong_input = false;

            // Get User-Input for radius
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

            // Output of perimeter and area of a circle
            Console.WriteLine($"Gewählter Radius: {radius}");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(Math.PI * Math.Pow(radius, 2), 2)}cm^2 Umfang: {Math.Round(2 * Math.PI * radius, 2)}cm");
        }

        /// <summary>
        /// Method to calculate area and perimeter of a rectangle.
        /// </summary>
        public static void CalcRectangle()
        {
            Console.WriteLine("Berechne Rechteck...");
            Console.WriteLine();

            // Variables
            double sideA = 0.0d;
            double sideB = 0.0d;
            bool wrong_input = false;

            // Get User-Input for both sides of rectangle
            do
            {
                wrong_input = false;
                try
                {
                    Console.Write("Seitenlänge A eingeben (in cm): ");
                    sideA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Seitenlänge B eingeben (in cm): ");
                    sideB = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}");
                    wrong_input = true;
                }
            }
            while (wrong_input);

            // Output of area and perimeter
            Console.WriteLine($"Gewählte Seitenlänge A: {sideA}cm || B: {sideB}cm");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(sideA * sideB, 2)}cm^2 Umfang: {Math.Round(2 * (sideA + sideB), 2)}cm");
        }

        /// <summary>
        /// Method to calculate area and perimeter of a triangle.
        /// </summary>
        public static void CalcTriangle()
        {
            Console.WriteLine("Berechne Dreieck...");
            Console.WriteLine();

            // Variables
            double sideA = 0.0d;
            double sideB = 0.0d;
            double sideC = 0.0d;
            bool wrong_input = false;

            // Get User-Input for the three sides
            do
            {
                wrong_input = false;
                try
                {
                    Console.Write("Seitenlänge A(Kathete) eingeben (in cm): ");
                    sideA = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Seitenlänge B(Kathete) eingeben (in cm): ");
                    sideB = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Seitenlänge C(Hypothenuse) eingeben (in cm): ");
                    sideC = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.GetType()} | {ex.Message}");
                    wrong_input = true;
                }
            }
            while (wrong_input);

            // Output area and perimeter
            Console.WriteLine($"Gewählte Seitenlänge A: {sideA} || cm B: {sideB}  || cm C: {sideC}cm");
            Console.WriteLine();
            Console.WriteLine($"Flächeninhalt: {Math.Round(sideA * sideB * .5, 2)}cm^2 Umfang: {Math.Round(sideA + sideB + sideC, 2)}cm");
        }
    }
}