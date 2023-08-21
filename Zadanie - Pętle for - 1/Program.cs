

using System;
using System.Linq;

namespace Zadania_petle
{
    class Program
    {
        static void Main()
        {
            //wczytywanie i parsowanie danych wejściowych
            string wejscie = Console.ReadLine();
            int[] dane = Array.ConvertAll<string, int>(wejscie.Split(" "), int.Parse);
            // Twój kod

            short a = (short)dane[0];
            short b = (short)dane[1];
            

            short najwieksza = Math.Max(a, b);
            short najmniejsza = Math.Min(a, b);

            if (najmniejsza == najwieksza || najwieksza == najmniejsza+1)
            {
                Console.WriteLine("empty");

            }

            for (int i = najmniejsza + 1; i < najwieksza; i++)
            {

                if ((najwieksza - najmniejsza - 1)>10)
                {
                    Console.WriteLine($"{i}, {i + 1}, {i + 2}, ..., {najwieksza - 2}, {najwieksza - 1}");
                    break;
                }
                else
                {
                    if (i < najwieksza - 1)
                        Console.Write(i + ", ");
                    else
                    {
                        Console.Write(i);
                    }

                }
            }
        }
    }
}

