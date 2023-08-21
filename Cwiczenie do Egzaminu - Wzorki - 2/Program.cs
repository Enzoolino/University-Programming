

class Program
{


    const char CHAR = '*';
    static void Star() => Console.Write(CHAR);
    static void StarLn() => Console.WriteLine(CHAR);
    static void Space() => Console.Write(" ");
    static void SpaceLn() => Console.WriteLine(" ");
    static void NewLine() => Console.WriteLine(); 
   


    public static void iksior(int n)
    {
        if (n < 3) throw new ArgumentException("zbyt mały rozmiar");
        if (n % 2 == 0) n = n + 1;


        int[] medianArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            medianArray[i] = i;
        }
        int median = medianArray[(medianArray.Length/2) + 1];
        

        int countSpaces = 0;
        int countCenter = n + 1;
        

        for (int i = 0; i < n; i++)
        {
            countCenter--;

            if (countCenter > median)
            {

                if (countSpaces == 0)
                {
                    int spaces = n - 2;
                    Star();
                    for (int k = 0; k < spaces; k++)
                    {
                        Space();
                    }
                    Star();
                }
                else
                {
                    for (int k = 0; k < countSpaces; k++)
                    {
                        Space();

                    }
                    Star();

                    int leftspaces = n - 2 - countSpaces*2;

                    for (int k = 0; k < leftspaces; k++)
                    {
                        Space();

                    }
                    Star();

                    for (int k = 0; k < countSpaces; k++)
                    {
                        Space();

                    }

                }
                
                NewLine();
                countSpaces++;
            }
            else if (countCenter == median)
            {
                int countSpacesCenter = (n - 1) / 2;

                for (int k = 0; k < countSpacesCenter; k++)
                {
                    Space();
                }
                Star();

                for (int k = 0; k < countSpacesCenter; k++)
                {
                    Space();
                }
                NewLine();
                countSpaces--;

            }
            else if (countCenter < median)
            {

                if (countSpaces == 0)
                {
                    int spaces = n - 2;
                    Star();
                    for (int k = 0; k < spaces; k++)
                    {
                        Space();
                    }
                    Star();
                }

                else
                {
                    for (int k = 0; k < countSpaces; k++)
                    {
                        Space();
                    }
                    Star();

                    int leftspaces = n - 2 - countSpaces*2;

                    for (int k = 0; k < leftspaces; k++)
                    {
                        Space();
                    }
                    Star();

                    for (int k = 0; k < countSpaces; k++)
                    {
                        Space();
                    }
                }

                NewLine();
                countSpaces--;

            }
        }   
    }


    static void Main(string[] args)
    {
        iksior(14);
    }
}




