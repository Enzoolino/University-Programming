

using System;
using System.Globalization;
using System.Linq;

namespace Zadanie_ParametryTrojkata
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            // wczytaj dane
            // i wykonaj obliczenia

            string bokiInput = Console.ReadLine();
            string[] boki = bokiInput.Split("; ");


            double[] convertBoki = { Double.Parse(boki[0]), Double.Parse(boki[1]), Double.Parse(boki[2]) };

            Array.Sort(convertBoki);

            double bok1 = convertBoki[0];
            double bok2 = convertBoki[1];
            double bok3 = convertBoki[2];
            double najBok = convertBoki.Max();

         
            double obwód = (bok1 + bok2 + bok3);
            double pole = Math.Sqrt((obwód) / 2 * (obwód / 2 - bok1) * (obwód / 2 - bok2) * (obwód / 2 - bok3));

            string[] typ = {"prostokątny", "ostrokątny", "rozwartokątny"};


            if (bok1 <= 0 || bok2 <= 0 || bok3 <= 0)
            {
                Console.WriteLine("Błędne dane. Długości boków muszą być dodatnie!");
                return;
            }
            else if (bok1 + bok2 < bok3 || bok1 + bok3 < bok2 || bok2 + bok3 < bok1)
            {
                Console.WriteLine("Błędne dane. Trójkąta nie można zbudować!");
                return;
            }
            else
            {
                Console.WriteLine($"obwód = {obwód:N2}");
                Console.WriteLine($"pole = {pole:N2}");


                if ((bok1 * bok1 + bok2 * bok2) == najBok * najBok)
                {
                    Console.WriteLine($"trójkąt jest {typ[0]}");
                }
                else if ((bok1 * bok1 + bok2 * bok2) > najBok * najBok)
                {
                    Console.WriteLine($"trójkąt jest {typ[1]}");
                }
                else if ((bok1 * bok1 + bok2 * bok2) < najBok * najBok)
                {
                    Console.WriteLine($"trójkąt jest {typ[2]}");
                }



                if (bok1 == bok2 && bok1 == bok3 && bok2 == bok3)
                {
                    Console.WriteLine("trójkąt równoboczny");
                }
                else if (bok1 == bok2 || bok1 == bok3 || bok2 == bok3)
                {
                    Console.WriteLine("trójkąt równoramienny");
                }

            }





        }
    }
}





