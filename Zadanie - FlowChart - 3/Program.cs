



string input = Console.ReadLine();
int[] xyz = Array.ConvertAll<string, int>(input.Split(" "), int.Parse);

int x = xyz[0];
int y = xyz[1];
int z = xyz[2];

for (; ;)
{
    
    if (x > 0)
    {

        if (y > 0)
        {
            x--;
            y--;
            Console.Write("C");
            continue;
        }
        else
        {
            Console.Write("D");

            if (z > 0)
            {
                break;
            }
            else
            {
                Console.Write("G");
                break;
            }
        }

    }
    else
    {
        Console.Write("E");
        Console.Write("G");
        break;
    }

}