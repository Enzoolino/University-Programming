

using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        string nazwisko;
        int wiek;
        int wiekEmerytalny;

        nazwisko = Console.ReadLine();
        wiek = int.Parse(Console.ReadLine());
        wiekEmerytalny = int.Parse(Console.ReadLine());

        Console.WriteLine($"Witaj, {nazwisko}!");

        if (wiek < 0 || wiekEmerytalny < 0)
        {
            Console.WriteLine("Wiek nie może być ujemny!");
        }

        else if (wiek < wiekEmerytalny)
        {
            int x = wiekEmerytalny - wiek;
            int jedn = x % 10;
            string[] gramatyka = { "rok", "lata", "lat" };

            if (x == 1)
                Console.WriteLine($"Do emerytury brakuje Ci {x} {gramatyka[0]}!");
            else if (jedn == 2 || jedn == 3 || jedn == 4)
                Console.WriteLine($"Do emerytury brakuje Ci {x} {gramatyka[1]}!");
            else
                Console.WriteLine($"Do emerytury brakuje Ci {x} {gramatyka[2]}!");
        }

        else
        {
            Console.WriteLine("Jesteś emerytem!");
        }
    }
}