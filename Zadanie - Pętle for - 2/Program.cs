using System;
using System.Linq;
using System.Text;
//using System.Threading.Tasks.Dataflow;

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
            short c = (short)dane[2];



            if ((a == b && a == c && b == c) || c <= 0 || a == b || short.MaxValue < dane[0] || short.MaxValue < dane[1] || short.MaxValue < dane[2])
            {
                Console.WriteLine("empty");
            }
            else
            {
                short najwieksza = Math.Max(a, b);
                short najmniejsza = Math.Min(a, b);

              
                int[] inc = new int[najwieksza - najmniejsza - 1];
                int iterator = 0;

                StringBuilder sb = new StringBuilder();


                for (int i = najmniejsza + 1; i < najwieksza; i++)
                {

                    if (i % c == 0)
                    {
                        inc[iterator] = i;
                        iterator++;
                    }

                }

                if (iterator == 0)
                {
                    Console.WriteLine("empty");
                }
                else if (iterator <= 10)
                {
                    for (int i = 0; i < iterator; i++)
                        sb.Append(inc[i] + ", ");
                    sb.Remove(sb.Length - 2, 2);
                    Console.WriteLine(sb);
                }
                else
                {
                    sb.Append(inc[0] + ", ");
                    sb.Append(inc[1] + ", ");
                    sb.Append(inc[2] + ", ");
                    sb.Append("..., ");
                    sb.Append(inc[iterator - 2] + ", ");
                    sb.Append(inc[iterator - 1]);

                    Console.WriteLine(sb);

                }
            }
            
        }
    }
}
