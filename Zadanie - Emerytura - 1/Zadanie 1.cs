

using System;

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
            Console.WriteLine("Wiek nie może być ujemny!");
        else if (wiek < wiekEmerytalny)
        {
            int x = wiekEmerytalny - wiek;
            Console.WriteLine($"Do emerytury brakuje Ci {x} lat!");
        }
        else
        {
            Console.WriteLine("Jesteś emerytem!");
        }

    }
}