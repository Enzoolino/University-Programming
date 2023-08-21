


using System;
using System.Linq;

namespace RównanieKwadratowe
{
    class Równanie1
    {

        static void Main(string[] args)
        {


            int a = 1;
            int b = 3;
            int c = 2;
            

            QuadraticEquation(a, b, c);



        }

        public static void QuadraticEquation(int a, int b, int c)
        {

            double aConverted = a;
            double bConverted = b;
            double cConverted = c;


            // Obliczenie delta
            double delta = bConverted * bConverted - 4 * aConverted * cConverted;

            int precision = 2;


            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        Console.WriteLine("infinity");
                    }
                    else
                    {
                        Console.WriteLine("empty");
                    }
                }
                else
                {
                    if (c != 0)
                    {
                        double x1 = -cConverted / bConverted;

                        string formattedNumber1 = x1.ToString("F" + precision);

                        Console.WriteLine($"x={formattedNumber1}");
                    }
                    else
                    {
                        Console.WriteLine("x=0.00");
                    }

                }
            }
            else
            {

                if (delta > 0)
                {
                    // Obliczenie pierwiastków równania
                    double x1 = (-bConverted + Math.Sqrt(delta)) / (2 * aConverted);
                    double x2 = (-bConverted - Math.Sqrt(delta)) / (2 * aConverted);

                    //Wybranie mniejszego i większego pierwiastka
                    double minimal = Math.Min(x1, x2);
                    double maximal = Math.Max(x1, x2);

                    //Przełożenie pierwiastka na string, żeby dodać miejsca po przecinku
                    string formattedNumber1 = minimal.ToString("F" + precision);
                    string formattedNumber2 = maximal.ToString("F" + precision);


                    // Wypisanie pierwiastków w porządku rosnącym
                    Console.WriteLine($"x1={formattedNumber1}");
                    Console.WriteLine($"x2={formattedNumber2}");
                }
                else if (delta == 0)
                {
                    // Obliczenie jednego rzeczywistego pierwiastka
                    double x = -bConverted / (2 * aConverted);

                    //Przełożenie pierwiastka na string, żeby dodać miejsca po przecinku
                    string formattedNumber1 = x.ToString("F" + precision);

                    // Wypisanie pierwiastka
                    Console.WriteLine($"x={formattedNumber1}");
                }
                else if (delta < 0)
                {
                    // Brak rzeczywistych pierwiastków
                    Console.WriteLine("empty");
                }
                else
                {
                    // Nieskończony zbiór rozwiązań
                    Console.WriteLine("infinity");
                }
            }
        }
    }
}

