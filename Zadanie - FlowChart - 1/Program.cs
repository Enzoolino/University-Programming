



using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

string input = Console.ReadLine();

int[] xyz = Array.ConvertAll<string, int>(input.Split(" "), int.Parse);

int x = xyz[0];
int y = xyz[1];
int z = xyz[2];


Start:
if (x >0)
{
    if (y >0 )
    {
        x--;
        y--;
        Console.Write("C");
        goto Start;
    }
    else
    {
        Console.Write("D");
        if (z >0)
        {
            goto Stop;
        }
        else
        {
            Console.Write("G");
                goto Stop;
        }
    }
}
else
{
    Console.Write("E");
    Console.Write("G");
    goto Stop;
}

Stop:;


