

class Program
{



    static void Main(string[] args)
    {
        int n = 7;

        Wzorek(n);
    }


    public static void Wzorek(int n)
    {
        if (n < 3) throw new ArgumentException("Za mała wartość");


        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                

                for (int j = 0; j < n; j++)
                {
                    Console.Write('*');

                }
                Console.WriteLine();
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write('*');
                Console.WriteLine();
            }


        }


    }

    }
