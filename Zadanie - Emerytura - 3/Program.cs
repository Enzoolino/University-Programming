


var line = Console.ReadLine();
string[] values = line.Split(' ');

    string nazwisko = values[0];
    string wiek = values[1];
    string wiekEmeryturalny = values[2];
    
    if (int.Parse(wiek) < 0 || int.Parse(wiekEmeryturalny) < 0)
    {
        Console.WriteLine("Wiek nie może być ujemny!");
    }

    else if (int.Parse(wiek) < int.Parse(wiekEmeryturalny))
    {
        int x = int.Parse(values[2]) - int.Parse(values[1]);
        int jedn = x % 10;
        string[] gramatyka = { "rok", "lata", "lat" };

        if (x == 1)
            Console.WriteLine($"Witaj {nazwisko}! Do emerytury brakuje Ci {x} {gramatyka[0]}!");
        else if (jedn == 2 || jedn == 3 || jedn == 4)
            Console.WriteLine($"Witaj {nazwisko}! Do emerytury brakuje Ci {x} {gramatyka[1]}!");
        else
            Console.WriteLine($"Witaj {nazwisko}! Do emerytury brakuje Ci {x} {gramatyka[2]}!");
    }

    else
    {
        Console.WriteLine($"Witaj emerycie {nazwisko}!");
    }


