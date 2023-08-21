


namespace ConeEstimator
{
    class Program
    {
        static void Main(string[] args)
        {

            // Pobierz promień i wysokość ze standardowego wejścia
            string input = Console.ReadLine();
            string[] inputValues = input.Split(' ');
            if (inputValues.Length != 2)
            {
                Console.WriteLine("Nieprawidłowa liczba argumentów.");
                return;
            }

            int radius;
            if (!int.TryParse(inputValues[0], out radius))
            {
                Console.WriteLine("Nieprawidłowa wartość promienia.");
                return;
            }

            if (radius < 0)
            {
                Console.WriteLine("Ujemny argument.");
                return;
            }

            int height;
            if (!int.TryParse(inputValues[1], out height))
            {
                Console.WriteLine("Nieprawidłowa wartość wysokości.");
                return;
            }

            if (height < 0)
            {
                Console.WriteLine("Ujemny argument.");
                return;
            }

            if (height == 0 && radius == 0)
            {
                Console.WriteLine("Obiekt nie istnieje.");
                return;
            }


            // Oblicz objętość stożka
            double volume = (1.0 / 3.0) * Math.PI * radius * radius * height;

            // Wyświetl przedział objętości
            Console.WriteLine("Objętość stożka: {0} ≤ V ≤ {1}", (int)Math.Floor(volume), (int)Math.Ceiling(volume));

        }
    }
}