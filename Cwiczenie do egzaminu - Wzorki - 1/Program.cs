
class Program
{

    const char CHAR = '*';
    static void Star() => Console.Write(CHAR);
    static void StarLn() => Console.WriteLine(CHAR);
    static void Space() => Console.Write(" ");
    static void SpaceLn() => Console.WriteLine(" ");
    static void NewLine() => Console.WriteLine();


    public static void Prostokat(int n, int m)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 || i == m - 1)
                {
                    Star();
                }
                else
                {
                    if ( j == 0 || j == n - 1)
                    {
                        Star();
                    }
                    else
                    {
                        Space();
                    }
                    
                }
                
            }
            NewLine();
        }
    }

    public static void Main(string[] args)
    {
        Prostokat(8, 10);
    }





}